using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkCameraManager : MonoBehaviour
{
    void Start()
    {
        PhotonView photonView = gameObject.GetComponentInParent<PhotonView>();
        if(!photonView.IsMine)
        {
            Destroy(GetComponent<Camera>());
        }
    }
}
