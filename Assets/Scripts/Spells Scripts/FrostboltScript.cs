using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostboltScript : Projectiles
{
    [SerializeField] private GameObject SlowingParticle;

    [SerializeField] private float DebuffTime;
    [SerializeField] private float DebuffValue;

    private Buff Debuff;

    private void Start()
    {
        Debuff = new Buff(DebuffTime, DebuffValue);
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
            DamageTarget(Target);
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
        Debug.LogError(TargetParent.name);
        PlayerMovement targetMovement = TargetParent.GetComponent<PlayerMovement>();
        if (targetMovement!=null)
        {
            Debug.LogError("MovementDetected");
            targetMovement.AddBuff(Debuff);
        }
        ApplySlowingParticle(Target);
    }

    private void ApplySlowingParticle(GameObject Target)
    {
        GameObject effect = Instantiate(SlowingParticle, Target.transform);
        effect.transform.localPosition = Vector3.zero + new Vector3(0, 1, 0);
        effect.GetComponent<DestroyOverTime>().Lifetime = Debuff.Time;
    }

}
