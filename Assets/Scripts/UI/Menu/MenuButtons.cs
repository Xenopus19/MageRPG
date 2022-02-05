using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {

    [SerializeField] Button StartGameButton = null;
    [SerializeField] Button QuitGameButton = null;
    [SerializeField] Button DevelopersButton = null;
    [SerializeField] GameObject Developers;

    void Start() {
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
        if(StartGameButton != null) {
            StartGameButton.onClick.AddListener(StartGame);
        }
        if (QuitGameButton != null) {
            QuitGameButton.onClick.AddListener(QuitGame);
        }
        if (DevelopersButton != null) {
            DevelopersButton.onClick.AddListener(OpenDevelopers);
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

    public void OpenDevelopers() {
        Developers.SetActive(true);
        gameObject.SetActive(false);
    }

    public void CloseDevelopers() {
        Developers.SetActive(false);
        gameObject.SetActive(true);
    }
}
