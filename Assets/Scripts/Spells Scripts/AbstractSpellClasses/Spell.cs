using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Spell : MonoBehaviour
{
    [Header("Basic Spell Data")]
    public GameObject Caster;
    public float ActionAmount;
    public float ManaConsumption;
    public Sprite SpellIcon;
    public Animator anim;

    public void GetAnimator()
    {
        anim = Caster.GetComponent<Animator>();
    }

    public Health GetTargetHealth(GameObject Target)
    {
        if (Target.GetComponent<Health>() != null)
        {
            return Target.GetComponent<Health>();
        }
        else if (Target.GetComponentInChildren<Health>() != null)
        {
            return Target.GetComponentInChildren<Health>();
        }
        else if (Target.GetComponentInParent<Health>() != null)
        {
            return Target.GetComponentInParent<Health>();
        }
        else
        {
            return null;
        }
    }

    public void DamageTarget(GameObject Target)
    {
        if(GetTargetHealth(Target)!=null && GetTargetHealth(Target)!=GetTargetHealth(Caster))
        GetTargetHealth(Target).ReceiveDamage(ActionAmount);
    }

    public void IgnoreCollisionWithCaster()
    {
        if (Caster.GetComponent<Collider>() != null)
        {
            Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }

        for (int i = 0; i < Caster.transform.childCount; i++)
        {
            Collider CasterChildCollider = Caster.transform.GetChild(i).GetComponent<Collider>();
            if (CasterChildCollider != null)
            {
                Physics.IgnoreCollision(CasterChildCollider, gameObject.GetComponent<Collider>());
                //Debug.LogError(CasterChildCollider.gameObject.name);
            }

        }

        TurnOnCollider();
    }

    public void IgnoreCollisionWithSameCasterSpell(GameObject Target)
    {
        if (Target.GetComponent<Spell>()?.Caster == Caster)
        {
            Physics.IgnoreCollision(Target.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            return;
        }
    }

    public virtual void TurnOnCollider()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
