using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballScript : Projectiles
{
    private PhotonView photonView;

    protected void Start()
    {   
        photonView = GetComponent<PhotonView>();
        GetAnimator();
        anim.Play("FireBallAndFrostboltCastAnim");
        FlyForward();
        IgnoreCollisionWithCaster();
    }
    protected void OnCollisionEnter(Collision collision)
    {
        if (!isAlive)
            return;

        GameObject Target = collision.gameObject;
        Debug.Log(Target.name);
        if (Target.GetComponent<Spell>()?.Caster == Caster)
        {
            Debug.Log("Collision ignored");
            Physics.IgnoreCollision(Target.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            return;
        }
        else
        {
            if (PhotonNetwork.IsMasterClient)
            {
                DamageTarget(Target);
            }
            CreateCollisionEffects();
            isAlive = false;
            Destroy(gameObject);
        }
        
        //Debug.LogWarning(Target.name);
    }

    
}
