using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostboltScript : Projectiles
{
    [SerializeField] private GameObject SlowingEffect;
    [SerializeField] private float DebuffDuration;

    private void Start()
    {
        GetAnimator();
        anim.Play("FireBallAndFrostboltCastAnim");
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
            Debuff.DebuffTime = DebuffDuration;
            Debuff.SpeedToDecrease = 6;
        }
        ApplySlowingEffect();
    }

    private void ApplySlowingEffect()
    {
        GameObject effect = Instantiate(SlowingEffect, Caster.transform);
        effect.transform.position = Vector3.zero;
        effect.GetComponent<DestroyOverTime>().Lifetime = DebuffDuration;
    }

}
