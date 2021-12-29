using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class SpellCast : MonoBehaviour
{
    public Dictionary<string, GameObject> Spells = new Dictionary<string, GameObject>();
    public string SpellCode;

    [SerializeField] private GameObject FireBall;
    [SerializeField] private GameObject HealSpell;
    [SerializeField] private GameObject Frostbolt;
    [SerializeField] private GameObject StoneWall;
    [SerializeField] private GameObject IceBarrage;
    [SerializeField] private GameObject StaticField;
    [SerializeField] private GameObject Vampirism;
    [SerializeField] private GameObject FrozenOrb;
    [SerializeField] private GameObject HealingProjectile;
    [SerializeField] private GameObject Meteor;
    [SerializeField] private GameObject Spikes;

    [SerializeField] private GameObject PlayerCamera;

    private ManaPlayer manaPlayer;
    private SpellIconsChange spellRecognizedEffects;
    //private SpellCodeVisualisation spellCodeVisualisation;
    private PhotonView photonView;

    public bool IsUsingVampirism;
    private bool ParticleEffectCasted;

    [SerializeField] private GameObject CurrentSpell;
    private void Awake()
    {
        Spells.Add("12", FireBall);
        Spells.Add("175", HealSpell);
        Spells.Add("43", Frostbolt);
        Spells.Add("8576", StoneWall);
        Spells.Add("34", IceBarrage);
        Spells.Add("617", StaticField);
        Spells.Add("1475", Vampirism);
        Spells.Add("1243", FrozenOrb);
        Spells.Add("8127", HealingProjectile);
        Spells.Add("86275", Meteor);
        Spells.Add("142", Spikes);
    }    

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        spellRecognizedEffects = GetComponent<SpellIconsChange>();
        //spellCodeVisualisation = GameObject.Find("buttons").GetComponent<SpellCodeVisualisation>();
        manaPlayer = gameObject.GetComponent<ManaPlayer>();
        SpellCode = "";
    }
    private void Update()
    {
        GetSpell();
    }

    private void GetSpell()
    {
        if (!photonView.IsMine) return;
        photonView.RPC("PickSpell", RpcTarget.All, SpellCode);
    }
    [PunRPC]
    private void PickSpell(string SpellCode)
    {
        if (Spells.ContainsKey(SpellCode))
        {   
            CurrentSpell = Spells[SpellCode];
            if(!ParticleEffectCasted)
            {
                CreateParticles();
                ParticleEffectCasted = true;
            }
            if (photonView.IsMine)
            {
                ChangeSpellIcon();
            }
        }
        else
        {
            //Debug.LogWarning("Incorrect spell code.");
        }
    }
    public void StartCasting()
    {
        SpellCode = "";
        if (CurrentSpell != null)
        {
            CastSpell();
            //spellCodeVisualisation.OnCastVisualisation();
        }
        spellRecognizedEffects.DisableIconPanel();
    }
    public void CastSpell()
    {
        if(CanCast())
        {
            manaPlayer.DecrementMana(CurrentSpell.GetComponent<Spell>().ManaConsumption);
            photonView.RPC("Cast", RpcTarget.All);

            CurrentSpell = null;
            ChangeSpellIcon();
        }
    }
    [PunRPC]
    private void Cast()
    {
        ParticleEffectCasted = false;
        GameObject NewSpell = Instantiate(CurrentSpell, PlayerCamera.transform.position, PlayerCamera.transform.rotation);
        NewSpell.GetComponent<Spell>().Caster = gameObject;
    }

    private bool CanCast()
    {
        return manaPlayer.manaPlayer>=CurrentSpell.GetComponent<Spell>().ManaConsumption; 
    }

    private void ChangeSpellIcon()
    {
        spellRecognizedEffects.ChangeIcon(CurrentSpell);
    }
    private void CreateParticles()
    {
        spellRecognizedEffects.SpawnParticles(CurrentSpell);
    }
}
