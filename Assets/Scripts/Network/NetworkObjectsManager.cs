using UnityEngine;
using Photon.Pun;

public class NetworkObjectsManager : MonoBehaviour
{
    [SerializeField] private GameObject AboveTexts;
    [SerializeField] private Light TeamColoredLight;

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
            DestroyAboveTextsAndLights();
            MakePlayerInvisibleForCamera();
        }
    }

    private void DestroyAboveTextsAndLights()
    {
        AboveTexts.SetActive(false);
        TeamColoredLight.intensity=0;
    }

    private void MakePlayerInvisibleForCamera()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        parent.layer = 3;
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).gameObject.GetComponent<MeleeAttack>() == null)
                parent.transform.GetChild(i).gameObject.layer = 3;
        }
    }
}
