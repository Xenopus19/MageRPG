using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingToMenu : MonoBehaviour {
    private GameNetwork gameNetwork;
    public void GoToMenu() {
        gameNetwork.LeaveRoom();
    }
}
