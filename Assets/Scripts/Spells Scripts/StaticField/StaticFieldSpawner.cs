using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFieldSpawner : RayInstantiateSpell
{
    [SerializeField] private float BuffTime;
    [SerializeField] private float BuffValue;
    private void Start()
    {
        Caster.GetComponent<PlayerMovement>()?.AddBuff(new Buff(BuffTime, BuffValue));

        GameObject staticField = SpawnStructure(CreateRay());
        staticField.GetComponentInChildren<Spell>().Caster = Caster;
        staticField.SetActive(true);
    }
}
