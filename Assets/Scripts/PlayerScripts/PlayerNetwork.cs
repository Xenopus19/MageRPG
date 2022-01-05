using UnityEngine;
using Photon.Pun;

public class PlayerNetwork : MonoBehaviour
{
    public static GameObject LocalPlayerGO;

    public bool team;

    private PhotonView photonView;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(photonView.IsMine)
        {
            photonView.RPC("RPC_SetTeam", RpcTarget.Others, team);
        }
        
        if (GetComponent<PhotonView>().IsMine)
        {
            LocalPlayerGO = gameObject;
        }
    }

    [PunRPC]
    public void RPC_SetTeam(bool PlayerTeam)
    {
        team = PlayerTeam;
    }
}
