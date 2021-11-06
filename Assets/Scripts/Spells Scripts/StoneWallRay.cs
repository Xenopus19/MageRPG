using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWallRay : RayInstantiateSpell
{
    private void Start()
    {
        SpawnStructure(CreateRay());
    }
}
