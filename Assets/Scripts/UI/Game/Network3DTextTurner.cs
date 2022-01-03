using Photon.Pun;
using UnityEngine;

public class Network3DTextTurner : MonoBehaviour
{
    [SerializeField] GameObject[] Texts3D;

    private GameObject LocalPlayerGO;

    private void Start()
    {
        LocalPlayerGO = PlayerNetwork.LocalPlayerGO;
    }

    private void Update()
    {
        TurnText();
    }

    private void TurnText()
    {
        foreach(GameObject text in Texts3D)
        {
            if(LocalPlayerGO!=null)
            text?.transform.LookAt(LocalPlayerGO.transform);
        }
    }
}
