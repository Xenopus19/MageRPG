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
        gameObject.transform.Rotate(270f, 0f, 0f);
        gameObject.transform.position += new Vector3(0f, 2f, 0f);
        photonView = GetComponent<PhotonView>();

        FlyForward();
    }

    [SerializeField] private float UpwardPushForce;
    [SerializeField] private float UpwardJumpForce;
    private void OnTriggerEnter(Collider collision)
    {
        GameObject Target = collision.gameObject;

        if (Target.GetComponent<Rigidbody>() != null)
        {
            Target.GetComponent<Rigidbody>().AddForce(transform.forward * UpwardPushForce);
            DestroySpell();
        }
        else if (Target.GetComponent<CharacterController>() != null)
        {
            Target.GetComponent<PlayerMovement>().Jump(UpwardJumpForce, -9.81f);
            DestroySpell();
        }
    }
    [PunRPC]
    void DestroySpell()
    {
        Destroy(gameObject);
    }

}
