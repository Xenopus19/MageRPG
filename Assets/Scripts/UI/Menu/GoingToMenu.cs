using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingToMenu : MonoBehaviour {
    public GameObject gameNetworkManager;
    private GameNetwork gameNetwork;
    private void Start() {
        gameNetwork = gameNetworkManager.GetComponent<GameNetwork>();
    }
    public void GoToMenu() {
        gameNetwork.LeaveRoom();
    }
}
