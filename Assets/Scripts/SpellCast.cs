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
    public float force;
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
        Ray ray = new Ray();
        ray.origin = Camera.main.transform.position;
        ray.direction = Camera.main.transform.forward;

        GameObject Fireball = Instantiate(FireBall, gameObject.transform.position, Quaternion.identity);
        Rigidbody FireBallPhysics = Fireball.GetComponent<Rigidbody>();
        FireBallPhysics.AddForce(ray.direction * force);
    }
}
