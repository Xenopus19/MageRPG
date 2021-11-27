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
        iceBarrage.transform.SetParent(spawnerData.Caster.transform);
        iceBarrage.transform.localPosition = Vector3.zero;
    }
}
