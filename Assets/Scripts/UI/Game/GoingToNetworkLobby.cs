using UnityEngine;

public class GoingToNetworkLobby : MonoBehaviour {
    public GameObject gameNetworkManager;
    private GameNetwork gameNetwork;
    private void Start() {
        gameNetwork = gameNetworkManager.GetComponent<GameNetwork>();
    }
    public void GoToNetworkLobby() {
        gameNetwork.LeaveRoom();
    }
}
