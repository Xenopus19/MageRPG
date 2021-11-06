using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(Spell))]

public class TornadoScript : Projectiles
{
    private PhotonView photonView;
    private void Start()
    {
        IgnoreCollisionWithCaster();
        gameObject.transform.Rotate(270f, 0f, 0f);
        gameObject.transform.position += new Vector3(0f, 2f, 0f);
        photonView = GetComponent<PhotonView>();

        FlyForward();
    }

    [SerializeField] private float UpwardPushForce;
    private void OnTriggerEnter(Collider collision)
    {
        if (PhotonNetwork.IsMasterClient) 
        {
            GameObject Target = collision.gameObject.transform.parent?.gameObject;

            if (Target.GetComponent<Rigidbody>() != null)
            {
                Target.GetComponent<Rigidbody>().AddForce(transform.forward * UpwardPushForce);
                DestroySpell();
            }
            else if (Target.GetComponent<CharacterController>() != null)
            {
                AddImpact(Target);
                DestroySpell();
            }
        }
    }
    void AddImpact(GameObject Target)
    {
        Target.GetComponent<ImpactReceiver>().AddImpact(transform.forward, UpwardPushForce / 5);
    }

    [PunRPC]
    void DestroySpell()
    {
        Destroy(gameObject);
    }

}
