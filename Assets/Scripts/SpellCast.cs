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
    public float force;
    private ManaPlayer manaPlayer;
<<<<<<< HEAD
<<<<<<< HEAD
=======

    private GameObject CurrentSpell;
>>>>>>> main
=======

    private GameObject CurrentSpell;
>>>>>>> main
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
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ulong newSpellCode = SpellCode;
            SpellCode = 0;

            PickSpell(newSpellCode);
            if(CurrentSpell != null)
                CastSpell();
        }
    }
    private void PickSpell(ulong SpellCode)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if (CanCast()) {
        manaPlayer.DecrementMana();
=======
=======
>>>>>>> main
        if (Spells.ContainsKey(SpellCode))
        {
            CurrentSpell = Spells[SpellCode];
        }
        else
        {
            Debug.LogWarning("Incorrect spell code.");
        }
    }
<<<<<<< HEAD
>>>>>>> main
=======
>>>>>>> main

    public void CastSpell()
    {
        if (CanCast()) 
        {

            manaPlayer.DecrementMana();
            GameObject NewSpell = Instantiate(CurrentSpell, gameObject.transform.position, Quaternion.identity);
            NewSpell.GetComponent<FireballScript>().Caster = gameObject;
<<<<<<< HEAD

            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;

            Rigidbody SpellPhysics = NewSpell.GetComponent<Rigidbody>();
            SpellPhysics.AddForce(ray.direction * force);

<<<<<<< HEAD
        Rigidbody FireBallPhysics = NewFireball.GetComponent<Rigidbody>();
        FireBallPhysics.AddForce(ray.direction * force);
        }
    }
    private bool CanCast() {
        return manaPlayer.manaPlayer - 20f > 0; 
=======
=======

            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;

            Rigidbody SpellPhysics = NewSpell.GetComponent<Rigidbody>();
            SpellPhysics.AddForce(ray.direction * force);

>>>>>>> main
            CurrentSpell = null;
        }
    }
    private bool CanCast()
    {
        return manaPlayer.manaPlayer>=CurrentSpell.GetComponent<Spell>().ManaConsumption; 
<<<<<<< HEAD
>>>>>>> main
=======
>>>>>>> main
    }
}
