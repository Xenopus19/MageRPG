using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWallRay : RayInstantiateSpell
{
    private void Start()
    {
        GetAnimator();
        anim.Play("StoneWallCastingAnim");
        SpawnStructure(CreateRay(), true);
    }
}
