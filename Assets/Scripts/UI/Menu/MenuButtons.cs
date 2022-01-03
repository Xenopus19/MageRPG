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
            QuitGameButton.onClick.AddListener(QuitGame);
        }
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("NetworkLobby");
    }
    public void GoToMenu () {
        SceneManager.LoadScene("Menu");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }
}
