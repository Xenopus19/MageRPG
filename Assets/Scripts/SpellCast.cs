using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellCast : MonoBehaviour
{
    private static SpellCast Instance;
    public Dictionary<int, string> Spells = new Dictionary<int, string>();
    public GameObject FireBall;
    public static SpellCast GetInstance() => Instance;
    private void Awake()
    {
        Instance = this;
        Spells.Add(7896321, "Fireball");
    }
    public int SpellCode;
    private void Start()
    {
        SpellCode = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int newSpellCode = SpellCode;
            SpellCode = 0;
            string SpellName = Spells[newSpellCode];
            switch (SpellName)
            {
                case "Fireball":
                    CastFireball();
                    break;
            }
        }
    }
    public void CastFireball()
    {
        Instantiate(FireBall, gameObject.transform.position, Quaternion.identity);
    }
}
