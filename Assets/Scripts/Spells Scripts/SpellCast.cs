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
    public GameObject FireBall;
    public ulong SpellCode;
    [SerializeField] private GameObject HealSpell;

    private ManaPlayer manaPlayer;
    private SpellIconsChange iconsChange;
    private PhotonView photonView;

    private GameObject CurrentSpell;
    private void Awake()
    {
        Spells.Add(7896321, FireBall);
        Spells.Add(7536, HealSpell);
    }    

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        iconsChange = GetComponent<SpellIconsChange>();
        SpellCode = 0;
        manaPlayer = gameObject.GetComponent<ManaPlayer>();
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
                photonView.RPC("CastSpell", RpcTarget.AllViaServer);
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
    [PunRPC]
    public void CastSpell()
    {
        if(CanCast())
        {
            manaPlayer.DecrementMana(CurrentSpell.GetComponent<Spell>().ManaConsumption);
            GameObject NewSpell = Instantiate(CurrentSpell, gameObject.transform.position, Quaternion.identity);
            NewSpell.GetComponent<Spell>().Caster = gameObject;

            CurrentSpell = null;
            OnSpellChange();
        }
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
