using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(Spell))]
public class FireballScript : Projectiles
{
    private PhotonView photonView;
    private void Start()
    {
        Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        for(int i = 0; i < Caster.transform.childCount; i++)
        {
            if(Caster.transform.GetChild(i).GetComponent<Collider>()!=null)
            Physics.IgnoreCollision(Caster.transform.GetChild(i).GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
        photonView = GetComponent<PhotonView>();

        FlyForward();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;

        if (Target.GetComponent<Health>()!=null )
        {
            Target.GetComponent<Health>().ReceiveDamage(ActionAmount);
            photonView.RPC("DestroyFireball", RpcTarget.All);
        }
        else if(Target.GetComponentInChildren<Health>() != null)
        {
            Target.GetComponentInChildren<Health>().ReceiveDamage(ActionAmount);
            photonView.RPC("DestroyFireball", RpcTarget.All);
        }
        else
        {
            photonView.RPC("DestroyFireball", RpcTarget.All);
        }
    }
    [PunRPC]
    void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
