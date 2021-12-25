using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainScript : Spell
{
    Health CollidedPlayerHealth;

    private void OnCollisionEnter(Collision collision)
    {
        DamageTarget(collision.gameObject);
    }
}
