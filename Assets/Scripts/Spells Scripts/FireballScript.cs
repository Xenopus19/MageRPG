using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballScript : Projectiles
{
    private PhotonView photonView;

    private void Start()
    {
        /*Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        for(int i = 0; i < Caster.transform.childCount; i++)
        {
            Collider CasterChildCollider = Caster.transform.GetChild(i).GetComponent<Collider>();
            if (CasterChildCollider!=null)
            {
                Debug.LogError(Caster.transform.GetChild(i).name);
                Physics.IgnoreCollision(CasterChildCollider,gameObject.GetComponent<Collider>());
            }
            
        }*/
        
        photonView = GetComponent<PhotonView>();
        FlyForward();
        IgnoreCollisionWithCaster();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;
        //Debug.LogWarning(Target.name);
        if(PhotonNetwork.IsMasterClient)
        {
            DamageTarget(Target);
        }
        Destroy(gameObject);
    }
}
