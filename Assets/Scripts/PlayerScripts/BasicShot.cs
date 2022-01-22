using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BasicShot : MonoBehaviour
{
    [SerializeField] private GameObject BasicShotPrefab;
    [SerializeField] private float ShotCooldown;
    [SerializeField] private GameObject PlayerCamera;
    [SerializeField] private Transform LaunchPoint;

    private float TimeSinceLastShot;
    private PhotonView photonView;

    private void Start()
    {
        TimeSinceLastShot = 0;
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        TimeSinceLastShot += Time.deltaTime;
    }

    public void MakeBasicShot()
    {
        if(TimeSinceLastShot>=ShotCooldown)
        {
            photonView.RPC("Shoot", RpcTarget.All);
            TimeSinceLastShot = 0;
        }
    }

    [PunRPC]
    private void Shoot()
    {
        GameObject NewSpell = Instantiate(BasicShotPrefab, LaunchPoint.transform.position, PlayerCamera.transform.rotation);
        NewSpell.GetComponent<Spell>().Caster = gameObject;
    }
}
