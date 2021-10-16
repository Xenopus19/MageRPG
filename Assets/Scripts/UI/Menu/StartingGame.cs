using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingGame : MonoBehaviour {
    public void StartGame() {
        SceneManager.LoadScene("Arena1");
    }
}
