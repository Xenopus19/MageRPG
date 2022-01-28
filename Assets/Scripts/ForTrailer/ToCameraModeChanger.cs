using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ToCameraModeChanger : MonoBehaviour
{
    [SerializeField] private KeyCode ChangeKey;
    [SerializeField] private GameObject FlyingCamera;
    private void Update()
    {
        if(Input.GetKeyDown(ChangeKey))
        {
            PhotonNetwork.Instantiate(FlyingCamera.name, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
