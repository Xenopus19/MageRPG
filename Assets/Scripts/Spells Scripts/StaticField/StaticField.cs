using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticField : Spell
{
    [Space(2f)]
    [SerializeField] private float TimeBetweedStrikes;

    private float TimeSinceLastStrike;
    private Bounds ColliderBounds;

    private void Start()
    {
        TimeSinceLastStrike = 0;
        ColliderBounds = GetComponent<Collider>().bounds;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject target = other.gameObject;

        DamageTarget(target);
    }

    private void Update()
    {
        TimeSinceLastStrike += Time.deltaTime;

        if(TimeSinceLastStrike>=TimeBetweedStrikes)
        {
            MakeStrike();
            TimeSinceLastStrike = 0;
        }
    }

    private void MakeStrike()
    {
        Collider[] CollidersInside = Physics.OverlapBox(ColliderBounds.center, ColliderBounds.size/4);

        foreach(Collider collider in CollidersInside)
        {
            GameObject target = collider.gameObject;

            DamageTarget(target);
        }
    }
}
