using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHeal : Spell
{
    private void Start()
    {
        gameObject.transform.SetParent(Caster.transform);
        GetAnimator();
        anim.Play("HealCastAnim");
        Health CasterHealth = Caster.GetComponentInChildren<Health>();
        float SpellHealing = gameObject.GetComponent<Spell>().ActionAmount;
        CasterHealth.ReceiveHealing(SpellHealing);
        //Destroy(gameObject);
    }
}
