using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageTile : Spell
{
    private void Start()
    {
        Caster = GetComponentInParent<Spell>().Caster;
        //IgnoreCollisionWithCaster();
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageTarget(collision.transform.gameObject);
        Debug.LogError(collision.transform.gameObject.name);
        Destroy(gameObject);
    }
}
