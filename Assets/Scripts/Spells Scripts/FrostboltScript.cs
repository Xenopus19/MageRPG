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

        if(GetTargetHealth(Target)!=null)
        {
            GetTargetHealth(Target).ReceiveDamage(ActionAmount);
            Destroy(gameObject);
            ApplyMovementDebuff(Target);
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
        ApplySlowingEffect(Target);
    }

    private void ApplySlowingEffect(GameObject Target)
    {
        GameObject effect = Instantiate(SlowingEffect, Target.transform);
        effect.transform.localPosition = Vector3.zero + new Vector3(0, 1, 0);
        effect.GetComponent<DestroyOverTime>().Lifetime = DebuffDuration;
    }

}
