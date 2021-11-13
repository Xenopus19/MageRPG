using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoiningRoom : MonoBehaviour
{
    public GameObject roomButtons;
    public GameObject lobbyNetworkManager;

    private LobbyNetwork lobbyNetwork;

    private void Init() {
        lobbyNetwork = lobbyNetworkManager.GetComponent<LobbyNetwork>();
    }

    public void CreateJoinRoomPanel() {
        Init();

        gameObject.SetActive(true);
        roomButtons.SetActive(false);
    }

    public void Cancel() {
        roomButtons.SetActive(true);
        gameObject.SetActive(false);
    }
}
