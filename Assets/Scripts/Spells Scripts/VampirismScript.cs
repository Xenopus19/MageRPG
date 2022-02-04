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
        GetAnimator();
        anim.Play("HealCastAnim");
        CastersSpellCast = Caster.GetComponent<SpellCast>();
        CastersSpellCast.IsUsingVampirism = true;
        GetComponent<DestroyOverTime>().Lifetime = EffectTime;
        transform.SetParent(Caster.transform);
        transform.localPosition = Vector3.zero;
        transform.rotation = Caster.transform.rotation;
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
