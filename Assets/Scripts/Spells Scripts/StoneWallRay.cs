using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWallRay : RayInstantiateSpell
{
    private void Start()
    {
        GetAnimator();
        anim.Play("StoneWallCastingAnim");
        GameObject Wall = SpawnStructure(CreateRay(), false);
        Wall.GetComponent<Spell>().Caster = Caster;
    }
}
