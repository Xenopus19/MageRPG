using Photon.Pun;
using UnityEngine;

public class Network3DTextTurner : MonoBehaviour
{
    [SerializeField] public static GameObject LocalPlayerGO;

    [SerializeField] GameObject[] Texts3D;

    private void Start()
    {
        if(GetComponent<PhotonView>().IsMine)
        {
            LocalPlayerGO = gameObject;
        }
    }

    private void Update()
    {
        TurnText();
    }

    private void TurnText()
    {
        foreach(GameObject text in Texts3D)
        {
            text.transform?.LookAt(LocalPlayerGO.transform);
            //if (!(LocalPlayerGO.transform && text.transform) {
            //    text.transform?.LookAt(LocalPlayerGO.transform);
            //}
        }
    }
}
