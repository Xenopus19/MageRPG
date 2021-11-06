using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostboltScript : Projectiles
{
    private void Start()
    {
        IgnoreCollisionWithCaster();
        FlyForward();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;
        Debug.LogWarning(Target.name);

        if (Target.GetComponent<Health>() != null)
        {
            Target.GetComponent<Health>().ReceiveDamage(ActionAmount);
            Destroy(gameObject);
        }
        else if (Target.GetComponentInChildren<Health>() != null)
        {
            Target.GetComponentInChildren<Health>().ReceiveDamage(ActionAmount);
            Destroy(gameObject);
        }
        else if (Target.GetComponentInParent<Health>() != null)
        {
            Target.GetComponentInParent<Health>().ReceiveDamage(ActionAmount);
            ApplyMovementDebuff(Target);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ApplyMovementDebuff(GameObject Target)
    {
        GameObject TargetParent = Target.transform.parent.gameObject;
        if (Target.GetComponentInParent<PlayerMovement>()!=null)
        {
            DecreaseSpeed Debuff = TargetParent.AddComponent<DecreaseSpeed>();
            Debuff.DebuffTime = 10f;
            Debuff.SpeedToDecrease = 6;
        }
    }

}
