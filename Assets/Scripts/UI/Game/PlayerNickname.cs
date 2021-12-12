using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class PlayerNickname : MonoBehaviour
{
    private void Start()
    {
        PhotonView photonView = GetComponentInParent<PhotonView>();

        gameObject.GetComponent<TextMesh>().text = photonView.Owner.NickName;
    }
}
