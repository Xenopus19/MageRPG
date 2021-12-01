using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSpawner : MonoBehaviour
{
    [SerializeField] private GameObject IceBarrageGO;

    private Spell spawnerData;

    private void Start()
    {
        spawnerData = GetComponent<Spell>();
        GameObject iceBarrage = Instantiate(IceBarrageGO);
        iceBarrage.GetComponent<Spell>().Caster = spawnerData.Caster;
        iceBarrage.transform.SetParent(spawnerData.Caster.transform);
        iceBarrage.transform.localPosition = Vector3.zero + new Vector3(0, 0.3f, 0);
        for(int i = 0; i<=iceBarrage.transform.childCount-1; i++)
        {
            iceBarrage.transform.GetChild(i).GetComponent<Spell>().Caster = spawnerData.Caster;
        }
        iceBarrage.SetActive(true);
    }
}
