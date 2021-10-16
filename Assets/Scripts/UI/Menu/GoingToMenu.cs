using UnityEngine;
using UnityEngine.SceneManagement;

public class GoingToMenu : MonoBehaviour {
    public void GoToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
