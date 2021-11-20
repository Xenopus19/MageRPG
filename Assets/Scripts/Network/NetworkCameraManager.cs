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
            Destroy(GetComponent<AudioListener>());
        }
        else
        {
            GameObject parent = gameObject.transform.parent.gameObject;
            parent.layer = 3;
            for(int i = 0; i<parent.transform.childCount; i++)
            {
                if(parent.transform.GetChild(i).gameObject.GetComponent<MeleeAttack>()==null)
                parent.transform.GetChild(i).gameObject.layer = 3;
            }
        }
    }
}
