using Photon.Pun;
using UnityEngine;

public class JoiningRoom : MonoBehaviour
{
    public GameObject roomButtons;
    public GameObject lobbyNetworkManager;
    private LobbyNetwork lobbyNetwork;

    private void Init() 
    {
        lobbyNetwork = lobbyNetworkManager.GetComponent<LobbyNetwork>();
    }

    public void CreateJoinRoomPanel() 
    {
        Init();
        gameObject.SetActive(true);
        roomButtons.SetActive(false);
    }

    public void Cancel() 
    {
        if(PhotonNetwork.CurrentRoom!=null)
        {
            lobbyNetwork.LeaveRoom();
        }
        roomButtons.SetActive(true);
        gameObject.SetActive(false);
    }
}
