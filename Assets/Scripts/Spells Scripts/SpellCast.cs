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
    [SerializeField] private GameObject Tornado;
    [SerializeField] private GameObject Frostbolt;
    [SerializeField] private GameObject StoneWall;
    [SerializeField] private GameObject IceBarrage;

    [SerializeField] private GameObject PlayerCamera;

    private ManaPlayer manaPlayer;
    private SpellIconsChange iconsChange;
    private SpellCodeVisualisation spellCodeVisualisation;
    private PhotonView photonView;


    [SerializeField] private GameObject CurrentSpell;
    private void Awake()
    {
        Spells.Add("12", FireBall);
        Spells.Add("175", HealSpell);
        //Spells.Add(412589, Tornado);
        Spells.Add("43", Frostbolt);
        Spells.Add("8576", StoneWall);
        Spells.Add("34", IceBarrage);
    }    

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        iconsChange = GetComponent<SpellIconsChange>();
        spellCodeVisualisation = GameObject.Find("buttons").GetComponent<SpellCodeVisualisation>();
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
            if(photonView.IsMine)
            {
                OnSpellChange();
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
            spellCodeVisualisation.OnCastVisualisation();
        }
        iconsChange.DisableIconPanel();
    }
    public void CastSpell()
    {
        if(CanCast())
        {
            manaPlayer.DecrementMana(CurrentSpell.GetComponent<Spell>().ManaConsumption);
            photonView.RPC("Cast", RpcTarget.All);

            CurrentSpell = null;
            OnSpellChange();
        }
    }
    [PunRPC]
    private void Cast()
    {
        GameObject NewSpell = Instantiate(CurrentSpell, PlayerCamera.transform.position, PlayerCamera.transform.rotation);
        NewSpell.GetComponent<Spell>().Caster = gameObject;
    }

    private bool CanCast()
    {
        return manaPlayer.manaPlayer>=CurrentSpell.GetComponent<Spell>().ManaConsumption; 
    }

    private void OnSpellChange()
    {
        iconsChange.ChangeIcon(CurrentSpell);
    }
}
