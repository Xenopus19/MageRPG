using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManaItemsCreator : MonoBehaviour
{
    [SerializeField] private GameObject ManaItem;
    [SerializeField] private float SpawnCooldown;

    private void Start()
    {
        InvokeRepeating("CreateManaItem", SpawnCooldown, SpawnCooldown);
    }

    private void CreateManaItem()
    {
        Vector3 Pos = new Vector3(Random.Range(20, 37), 0.36f, Random.Range(8, 34));

        GameObject NewItem = PhotonNetwork.Instantiate(ManaItem.name, Pos, Quaternion.identity);
    }
}
