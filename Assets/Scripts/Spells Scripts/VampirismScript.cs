using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampirismScript : Spell
{
    private float time;
    [SerializeField] private float EffectTime;
    private SpellCast CastersSpellCast;
    private void Start()
    {
        CastersSpellCast = Caster.GetComponent<SpellCast>();
        CastersSpellCast.IsUsingVampirism = true;
    }
    void Update()
    {
        time += Time.deltaTime;
        if(CastersSpellCast.IsUsingVampirism == false)
        {
            CastersSpellCast.IsUsingVampirism = true;
        }
        if (time >= EffectTime)
        {
            CastersSpellCast.IsUsingVampirism = false;
        }
    }
}
