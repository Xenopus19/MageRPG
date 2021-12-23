using Photon.Pun;
using UnityEngine;

public class HealingProjectile :Projectiles
{
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
                Health health = GetTargetHealth(Target);
                if(health!=null)
                {
                    health.ReceiveHealing(ActionAmount);
                }
            }
            CreateCollisionEffects();
            isAlive = false;
            Destroy(gameObject);
        }
    }

}
