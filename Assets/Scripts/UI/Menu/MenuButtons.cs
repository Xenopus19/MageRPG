using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    void Start() {
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("NetworkLobby");
    }

    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
