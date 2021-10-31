using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;

public class SpellCast : MonoBehaviour
{
    public Dictionary<ulong, GameObject> Spells = new Dictionary<ulong, GameObject>();
    public ulong SpellCode;
    [SerializeField] private GameObject FireBall;
    [SerializeField] private GameObject HealSpell;
    [SerializeField] private GameObject Tornado;

    private ManaPlayer manaPlayer;
    private SpellIconsChange iconsChange;
    private PhotonView photonView;

    private GameObject CurrentSpell;
    private void Awake()
    {
        Spells.Add(7896321, FireBall);
        Spells.Add(7536, HealSpell);
        Spells.Add(412589, Tornado);
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
        PickAndCastSpell();
    }

    [PunRPC]
    private void PickAndCastSpell()
    {
        if (!photonView.IsMine) return;
        PickSpell(SpellCode);
        if (Input.GetMouseButtonDown(0))
        {
            SpellCode = 0;
            if (CurrentSpell != null)
                CastSpell();
            iconsChange.DisableIconPanel();
        }
    }
    private void PickSpell(ulong SpellCode)
    {
        if (Spells.ContainsKey(SpellCode))
        {
            CurrentSpell = Spells[SpellCode];
            OnSpellChange();
        }
        else
        {
            //Debug.LogWarning("Incorrect spell code.");
        }
    }
    public void CastSpell()
    {
        if(CanCast())
        {
            manaPlayer.DecrementMana(CurrentSpell.GetComponent<Spell>().ManaConsumption);
            Cast(CurrentSpell.name);

            CurrentSpell = null;
            OnSpellChange();
        }
    }
    private void Cast(string SpellName)
    {
        GameObject NewSpell = PhotonNetwork.Instantiate(SpellName, gameObject.transform.position, Quaternion.identity);
        NewSpell.GetComponent<Spell>().SyncCasterOnAllPrefabs(gameObject.name);
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
