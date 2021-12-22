using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    [SerializeField] Button StartGameButton = null;
    [SerializeField] Button QuitGameButton = null;

    void Start() {
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        if(StartGameButton != null) {
            StartGameButton.onClick.AddListener(StartGame);
        }
        if (QuitGameButton != null) {
            QuitGameButton.onClick.AddListener(StartGame);
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("NetworkLobby");
    }
}
