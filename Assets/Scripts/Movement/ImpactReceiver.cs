using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactReceiver : MonoBehaviour
{
    float mass = 3.0F; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;
    private PhotonView photonView;
    // Use this for initialization
    void Start()
    {
        character = GetComponent<CharacterController>();
        photonView = GetComponent<PhotonView>(); 
    }

    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.2F) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
    // call this function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        photonView.RPC("RPC_AddImpact", RpcTarget.All, dir.x, dir.y, dir.z, force);
    }


    [PunRPC]
    private void RPC_AddImpact(float X, float Y, float Z, float force)
    {
        Debug.LogError("ImpactAdded");
        Vector3 dir = new Vector3(X, Y, Z);
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }
}
