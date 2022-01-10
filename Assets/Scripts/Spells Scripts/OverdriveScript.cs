using Photon.Pun;
using UnityEngine;

public class OverdriveScript : Spell
{
    [Header("Overdrive Values")]
    [SerializeField] private float EffectDuration;
    [SerializeField] private float ManaRefillNumber;
    [SerializeField] private float MatkBonus;
    [SerializeField] private GameObject VisualEffect;

    private void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            GetTargetHealth(Caster).ReceiveDamage(ActionAmount);
        }
        ApplyMatkBuff();
        RefillMana();
        CreateVisualEffect();
    }

    private void ApplyMatkBuff()
    {
        AdditionalMagicAttack matk = Caster.GetComponent<AdditionalMagicAttack>();
        if(matk!=null)
        {
            matk.AddBuff(new Buff(EffectDuration, MatkBonus));
        }
    }

    private void RefillMana()
    {
        ManaPlayer mana = Caster.GetComponent<ManaPlayer>();
        if(mana!=null)
        {
            mana.RefillMana(ManaRefillNumber);
        }
    }

    private void CreateVisualEffect()
    {
        GameObject effect = Instantiate(VisualEffect, Caster.transform);
        effect.GetComponent<DestroyOverTime>().Lifetime = EffectDuration;
    }
}
