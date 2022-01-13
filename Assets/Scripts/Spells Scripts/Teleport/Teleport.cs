using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Spell
{ 
    private void Start()
    {
         Caster.transform.position = transform.position;
        Debug.LogError("Caster teleported");
    }
}
