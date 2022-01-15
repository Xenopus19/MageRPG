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
        GetAnimator();
        anim.Play("FireBallAndFrostboltCastAnim");
        FlyForward();
        IgnoreCollisionWithCaster();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!isAlive)
            return;
        gameObject.GetComponent<Collider>().enabled = false;
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

            DestroySpell();
        }
        
        //Debug.LogWarning(Target.name);
    }

    private void DestroySpell()
    {
        CreateCollisionEffects();
        isAlive = false;
        Destroy(gameObject);
    }


}
