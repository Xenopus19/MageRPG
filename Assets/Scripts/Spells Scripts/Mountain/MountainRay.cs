using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainRay : RayInstantiateSpell
{
    private void Start()
    {
        GetAnimator();
        anim.Play("StoneWallCastingAnim");
        SpawnStructure(CreateRay(), false);
    }
}
