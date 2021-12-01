using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballScript : Projectiles
{
    private PhotonView photonView;

    private void Start()
    {   
        photonView = GetComponent<PhotonView>();
        FlyForward();
        IgnoreCollisionWithCaster();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;
        ExplosionEffect(gameObject);
        //Debug.LogWarning(Target.name);
        if (PhotonNetwork.IsMasterClient)
        {
            DamageTarget(Target);
        }
        Destroy(gameObject);
    }
    private void ExplosionEffect(GameObject Firebal)
    {
        GameObject Explosion = Instantiate(EffectOnColiding, Firebal.transform.position ,Quaternion.identity);
    }
}
