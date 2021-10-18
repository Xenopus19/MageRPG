using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellCast : MonoBehaviour
{
    private static SpellCast Instance;
    public Dictionary<ulong, string> Spells = new Dictionary<ulong, string>();
    public GameObject FireBall;
    public float force;
    private ManaPlayer manaPlayer;
    public static SpellCast GetInstance() => Instance;
    private void Awake()
    {
        Instance = this;
        Spells.Add(7896321, "FireBall");
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

            switch (Spells[newSpellCode])
            {
                case "FireBall":
                    CastFireball();
                    break;
            }
        }
    }
    public void CastFireball()
    {
        if (CanCast()) {
        manaPlayer.DecrementMana();

        GameObject NewFireball = Instantiate(FireBall, gameObject.transform.position, Quaternion.identity);
        NewFireball.GetComponent<FireballScript>().Caster = gameObject;

        Ray ray = new Ray();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;

        Rigidbody FireBallPhysics = NewFireball.GetComponent<Rigidbody>();
        FireBallPhysics.AddForce(ray.direction * force);
        }
    }
    private bool CanCast() {
        return manaPlayer.manaPlayer - 20f > 0; 
    }
}
