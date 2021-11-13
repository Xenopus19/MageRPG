using UnityEngine;
using UnityEngine.UI;

public class NameOfPlayer : MonoBehaviour {
    private string playerName;
    private InputField inputName;

    void Start() {
        if (PlayerPrefs.HasKey("PlayerName")) 
            playerName = PlayerPrefs.GetString("PlayerName");

        inputName = gameObject.GetComponent<InputField>();
        inputName.text = playerName;
    }

    public void SaveName() {
        PlayerPrefs.SetString("PlayerName", inputName.text);
    }

    public void EndEditingName() {
        GameObject.Find("NamePanel").SetActive(false);
    }
}
