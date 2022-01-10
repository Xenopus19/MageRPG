using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithScript : Spell
{ 
    [SerializeField] private GameObject MonolithColumn;
    [SerializeField] private float RadiusOfAction;
    [SerializeField] private float Lifetime;
    [SerializeField] private GameObject DestroyParticle;

    [Header("Debuff Params")]
    [SerializeField] private float DebuffTime;
    [SerializeField] private float MagicDebuffValue;
    [SerializeField] private float SpeedDebuffValue;

    private float TimeSinceLastDebuffing = 0;
    private bool CasterTeam;
    private void Start()
    {
        CasterTeam = Caster.GetComponent<PlayerNetwork>().team;
        StartCoroutine("DelayedDestroy");
    }

    private void Update()
    {
        TimeSinceLastDebuffing += Time.deltaTime;

        if(TimeSinceLastDebuffing>=DebuffTime)
        {
            CurseTargets(GetTargets());
            TimeSinceLastDebuffing = 0;
        }
    }

    private IEnumerator DelayedDestroy()
    {
        Debug.Log("delayed destroy casted");
        yield return new WaitForSeconds(Lifetime);
        DestroyMonolith();
    }

    private GameObject[] GetTargets()
    {
        Collider[] colliders =  Physics.OverlapSphere(MonolithColumn.transform.position, RadiusOfAction);
        GameObject[] targets = new GameObject[colliders.Length];
        for(int i = 0; i<colliders.Length;i++)
        {
            targets[i] = colliders[i].gameObject;
        }

        return targets;
    }

    private void CurseTargets(GameObject[] Targets)
    {
        foreach (GameObject target in Targets)
        {
            if (target.GetComponent<PlayerNetwork>() == null || target.GetComponent<PlayerNetwork>().team == CasterTeam) continue;

            SetMovementDebuff(target);
            SetMagicDebuff(target);
        }
    }

    private void SetMovementDebuff(GameObject Target)
    {
        PlayerMovement movement = Target.GetComponent<PlayerMovement>();

        if(movement!=null)
        {
            movement.AddBuff(new Buff(DebuffTime, SpeedDebuffValue));
        }
    }

    private void SetMagicDebuff(GameObject Target)
    {
        AdditionalMagicAttack Matk = Target.GetComponent<AdditionalMagicAttack>();

        if(Matk!=null)
        {
            Matk.AddBuff(new Buff(DebuffTime, MagicDebuffValue));
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void DestroyMonolith()
    {
        Debug.Log("destroy mobolith casted ");
        Instantiate(DestroyParticle, MonolithColumn.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
