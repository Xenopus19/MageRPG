using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpawner : RayInstantiateSpell
{
    private void Start()
    {
        GameObject teleportDestination = SpawnStructure(CreateRay(), false, 10);
        if (teleportDestination != null)
        {
            teleportDestination.GetComponent<Spell>().Caster = Caster;

        }
            
    }
}
