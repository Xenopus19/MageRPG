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
        Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        for (int i = 0; i < Caster.transform.childCount; i++)
        {
            if (Caster.transform.GetChild(i).GetComponent<Collider>() != null)
                Physics.IgnoreCollision(Caster.transform.GetChild(i).GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
        photonView = GetComponent<PhotonView>();

        FlyForward();
    }

    [SerializeField] private float UpwardPushForce;
    private void OnTriggerEnter(Collider collision)
    {
        GameObject Target = collision.gameObject;

        if (Target.GetComponent<Rigidbody>() != null)
        {
            Target.GetComponent<Rigidbody>().AddForce(transform.forward * UpwardPushForce);
            photonView.RPC("DestroySpell", RpcTarget.All);
        }
        else if (Target.GetComponentInChildren<Rigidbody>() != null)
        {
            Target.GetComponentInChildren<Rigidbody>().AddForce(transform.forward * UpwardPushForce); ;
            photonView.RPC("DestroySpell", RpcTarget.All);
        }
    }
    [PunRPC]
    void DestroySpell()
    {
        Destroy(gameObject);
    }

}
