using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : RayInstantiateSpell
{
    private void Start()
    {
        GameObject meteor = SpawnStructure(CreateRay(), false);
        if(meteor!=null)
        meteor.GetComponent<Spell>().Caster = Caster;
    }
}
