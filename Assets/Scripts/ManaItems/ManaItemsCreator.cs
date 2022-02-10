using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManaItemsCreator : MonoBehaviour
{
    [SerializeField] private GameObject ManaItem;
    [SerializeField] private float SpawnCooldown;
    [SerializeField] private GameObject Fireworks;

    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        InvokeRepeating("CreateManaItem", SpawnCooldown, SpawnCooldown);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Fireworks.SetActive(true);
        }
    }

    private void CreateManaItem()
    {
        Vector3 Pos = new Vector3(Random.Range(-28, 62), 45f, Random.Range(-19, 82));
        photonView.RPC("RPC_CreateManaItem", RpcTarget.All, Pos.x, Pos.z);
    }
    [PunRPC]
    public void RPC_CreateManaItem(float x, float z)
    {
        GameObject NewItem = Instantiate(ManaItem, new Vector3(x, 45f, z), Quaternion.identity);
    }
}
