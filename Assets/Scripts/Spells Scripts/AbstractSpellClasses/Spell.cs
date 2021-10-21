using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    public GameObject Caster;
    public float Damage;
    public float ManaConsumption;
    public Sprite SpellIcon;

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
