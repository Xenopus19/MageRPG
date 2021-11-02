using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballScript : Projectiles
{
    private PhotonView photonView;
    private void Start()
    {
        Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        for(int i = 0; i < Caster.transform.childCount; i++)
        {
            
            if(Caster.transform.GetChild(i).GetComponent<Collider>()!=null)
            {
                Debug.LogError(Caster.transform.GetChild(i).name);

            }
            
        }
        photonView = GetComponent<PhotonView>();

        FlyForward();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;
        Debug.LogError(Target.name);

        if (Target.GetComponent<Health>()!=null )
        {
            Target.GetComponent<Health>().ReceiveDamage(ActionAmount);
            //Destroy(gameObject);
        }
        else if(Target.GetComponentInChildren<Health>() != null)
        {
            Target.GetComponentInChildren<Health>().ReceiveDamage(ActionAmount);
            //Destroy(gameObject);
        }
        else if(Target.GetComponentInParent<Health>()!=null)
        {
            Target.GetComponentInParent<Health>().ReceiveDamage(ActionAmount);
            //Destroy(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }
}
