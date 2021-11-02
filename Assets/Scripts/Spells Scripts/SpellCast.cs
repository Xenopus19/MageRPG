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
    [SerializeField] private GameObject PlayerCamera;

    private ManaPlayer manaPlayer;
    private SpellIconsChange iconsChange;
    private PhotonView photonView;


    [SerializeField] private GameObject CurrentSpell;
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

    private void PickAndCastSpell()
    {
        if (!photonView.IsMine) return;
        photonView.RPC("PickSpell", RpcTarget.All, SpellCode);
        if (Input.GetMouseButtonDown(0))
        {
            SpellCode = 0;
            if (CurrentSpell != null)
                CastSpell();
            iconsChange.DisableIconPanel();
        }
    }
    [PunRPC]
    private void PickSpell(int SpellCode)
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
        GameObject NewSpell = Instantiate(CurrentSpell, PlayerCamera.transform.position, Quaternion.identity);
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
