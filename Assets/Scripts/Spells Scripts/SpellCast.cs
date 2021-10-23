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
    [SerializeField] private GameObject HealSpell;

    private ManaPlayer manaPlayer;
    private SpellIconsChange iconsChange;

    private GameObject CurrentSpell;
    public static SpellCast GetInstance() => Instance;
    private void Awake()
    {
        Instance = this;
        Spells.Add(7896321, FireBall);
        Spells.Add(7536, HealSpell);
    }

    public ulong SpellCode;

    private void Start()
    {
        iconsChange = GetComponent<SpellIconsChange>();
        SpellCode = 0;
        manaPlayer = gameObject.GetComponent<ManaPlayer>();
    }
    private void Update()
    {
        PickSpell(SpellCode);
        if (Input.GetMouseButtonDown(0))
        {
            ulong newSpellCode = SpellCode;
            SpellCode = 0;
            if(CurrentSpell != null)
                CastSpell();
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
        if (CanCast()) 
        {
            manaPlayer.DecrementMana(CurrentSpell.GetComponent<Spell>().ManaConsumption);
            GameObject NewSpell = Instantiate(CurrentSpell, gameObject.transform.position, Quaternion.identity);
            NewSpell.GetComponent<Spell>().Caster = gameObject;

            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;

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
