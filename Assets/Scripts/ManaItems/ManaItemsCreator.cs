using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManaItemsCreator : MonoBehaviour
{
    [SerializeField] private GameObject ManaItem;
    [SerializeField] private float SpawnCooldown;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        InvokeRepeating("CreateManaItem", SpawnCooldown, SpawnCooldown);
    }

    private void CreateManaItem()
    {
        Vector3 Pos = new Vector3(Random.Range(28, 43), 0.5f, Random.Range(13, 44));
        photonView.RPC("RPC_CreateManaItem", RpcTarget.All, Pos.x, Pos.z);
    }
    [PunRPC]
    public void RPC_CreateManaItem(float x, float z)
    {
        GameObject NewItem = Instantiate(ManaItem, new Vector3(x, 0.5f, z), Quaternion.identity);
    }
}
