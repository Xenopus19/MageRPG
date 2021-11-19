using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class SpellCast : MonoBehaviour
{
    public Dictionary<int, GameObject> Spells = new Dictionary<int, GameObject>();
    public int SpellCode;

    [SerializeField] private GameObject FireBall;
    [SerializeField] private GameObject HealSpell;
    [SerializeField] private GameObject Tornado;
    [SerializeField] private GameObject Frostbolt;
    [SerializeField] private GameObject StoneWall;

    [SerializeField] private GameObject PlayerCamera;

    private ManaPlayer manaPlayer;
    private SpellIconsChange iconsChange;
    private PhotonView photonView;


    [SerializeField] private GameObject CurrentSpell;
    private void Awake()
    {
        Spells.Add(12, FireBall);
        Spells.Add(175, HealSpell);
        //Spells.Add(412589, Tornado);
        Spells.Add(43, Frostbolt);
        Spells.Add(8576, StoneWall);
    }    

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        iconsChange = GetComponent<SpellIconsChange>();
        manaPlayer = gameObject.GetComponent<ManaPlayer>();
        SpellCode = 0;
    }
    private void Update()
    {
        PickSpell();
    }

    private void PickSpell()
    {
        if (!photonView.IsMine) return;
        photonView.RPC("RPC_PickSpell", RpcTarget.All, SpellCode);
    }
    [PunRPC]
    private void RPC_PickSpell(int SpellCode)
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
        SpellCode = 0;
        if (CurrentSpell != null)
            CastSpell();
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
