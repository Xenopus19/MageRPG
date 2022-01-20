using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Spell
{
    [SerializeField] private GameObject RPC_Teleport;
    private void Start()
    {
         Caster.transform.position = transform.position;
        Debug.LogWarning("Caster teleported");
    }
}
