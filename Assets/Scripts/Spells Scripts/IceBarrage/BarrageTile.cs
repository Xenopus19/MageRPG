using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageTile : Spell
{
    private void Start()
    {
        Caster = GetComponentInParent<Spell>().Caster;
        IgnoreCollisionWithCaster();
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageTarget(other.transform.gameObject);
        Destroy(gameObject);
    }
}
