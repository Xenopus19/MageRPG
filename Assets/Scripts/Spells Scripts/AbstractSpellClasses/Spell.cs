using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Spell : MonoBehaviour
{
    public GameObject Caster;
    public float ActionAmount;
    public float ManaConsumption;
    public Sprite SpellIcon;
    public Animator anim;

    public void GetAnimator()
    {
        anim = Caster.GetComponent<Animator>();
    }

    public void DamageTarget(GameObject Target)
    {
        if (Target.GetComponent<Health>() != null)
        {
            Target.GetComponent<Health>().ReceiveDamage(ActionAmount);
        }
        else if (Target.GetComponentInChildren<Health>() != null && Target.transform.parent.gameObject != Caster)
        {
            Target.GetComponentInChildren<Health>().ReceiveDamage(ActionAmount);
        }
        else if (Target.GetComponentInParent<Health>() != null && Target.transform.parent.gameObject != Caster)
        {
            Target.GetComponentInParent<Health>().ReceiveDamage(ActionAmount);
        }
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

    public virtual void TurnOnCollider()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
