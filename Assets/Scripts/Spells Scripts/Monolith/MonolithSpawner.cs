using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithSpawner : RayInstantiateSpell
{
    private void Start()
    {
        GetAnimator();
        anim.Play("StoneWallCastingAnim");
        GameObject monolith = SpawnStructure(CreateRay(), false);
        if (monolith != null)
            monolith.GetComponent<Spell>().Caster = Caster;
    }
}
