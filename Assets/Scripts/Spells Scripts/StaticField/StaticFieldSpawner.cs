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

        GameObject staticField = SpawnStructure(CreateRay(), false);
        if(staticField!=null)
        {
            staticField.GetComponent<StaticField>().Caster = Caster;
            staticField.SetActive(true);
        }
    }
}
