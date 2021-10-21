using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellCast : MonoBehaviour
{
    private static SpellCast Instance;
    public Dictionary<ulong, GameObject> Spells = new Dictionary<ulong, GameObject>();
    public GameObject FireBall;
    private ManaPlayer manaPlayer;
    [SerializeField] SpellIconsChange iconsChange;

    public GameObject CurrentSpell { get; private set; }
    public static SpellCast GetInstance() => Instance;
    private void Awake()
    {
        Instance = this;
        Spells.Add(7896321, FireBall);
    }

    public ulong SpellCode;

    private void Start()
    {
        SpellCode = 0;
        manaPlayer = gameObject.GetComponent<ManaPlayer>();
        iconsChange = gameObject.GetComponent<SpellIconsChange>();
    }
    private void Update()
    {
        PickSpell(SpellCode);
        if (Input.GetMouseButtonDown(0))
        {
            ulong newSpellCode = SpellCode;
            SpellCode = 0;

            //PickSpell(newSpellCode);
            if(CurrentSpell != null)
                CastSpell();
        }
    }
    private void PickSpell(ulong SpellCode)
    {
        if (Spells.ContainsKey(SpellCode))
        {
            CurrentSpell = Spells[SpellCode];
            iconsChange.ChangeIcon(CurrentSpell);
        }
        else
        {
            //Debug.LogWarning("Incorrect spell code.");
        }
    }

    public void CastSpell()
    {
        if (CanCast()) 
        {

            manaPlayer.DecrementMana(CurrentSpell.GetComponent<Spell>().ManaConsumption);
            GameObject NewSpell = Instantiate(CurrentSpell, gameObject.transform.position, Quaternion.identity);
            NewSpell.GetComponent<Spell>().Caster = gameObject;

            CurrentSpell = null;
            iconsChange.ChangeIcon(CurrentSpell);
        }
    }
    private bool CanCast()
    {
        return manaPlayer.manaPlayer>=CurrentSpell.GetComponent<Spell>().ManaConsumption; 
    }
}
