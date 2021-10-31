using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Spell : MonoBehaviour
{
    public GameObject Caster;
    public float ActionAmount;
    public float ManaConsumption;
    public Sprite SpellIcon;

    public void SyncCasterOnAllPrefabs(string CasterName)
    {
        Debug.LogError("Sync casted.");
        GetComponent<PhotonView>().RPC("SyncCaster", RpcTarget.All, CasterName);
    }
    [PunRPC]
    public void SyncCaster(string CasterName)
    {
        Debug.LogError("Rpc called." + CasterName);
        Caster = GameObject.Find(CasterName);
    }
}
