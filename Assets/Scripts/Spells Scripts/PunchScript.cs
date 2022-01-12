using Photon.Pun;
using System;
using UnityEngine;

public class PunchScript : Projectiles
{
    [SerializeField] private float Impact;
    private void Start()
    {
        IgnoreCollisionWithCaster();
        FlyForward();
    }
    private void OnCollisionEnter(Collision collision)
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
                ImpactReceiver impactReceiver = Target.GetComponent<ImpactReceiver>();
                if(impactReceiver)
                {
                    Debug.Log("Impact added");
                    impactReceiver.AddImpact(transform.forward, Impact);
                }
                DamageTarget(Target);
            }

            DestroySpell();
        }
    }

    private void DestroySpell()
    {
        CreateCollisionEffects();
        isAlive = false;
        Destroy(gameObject);
    }
}
