using UnityEngine;
using UnityEngine.UI;

public class NameOfPlayer : MonoBehaviour {
    private string playerName;
    private InputField inputName;

    private LobbyNetwork lobbyNetwork;

    void Start() {
        if (PlayerPrefs.HasKey("PlayerName")) 
            playerName = PlayerPrefs.GetString("PlayerName");

        inputName = gameObject.GetComponent<InputField>();
        inputName.text = playerName;

        lobbyNetwork = GameObject.Find("LobbyNetworkManager").GetComponent<LobbyNetwork>();
    }

    public void SaveName() {
        PlayerPrefs.SetString("PlayerName", inputName.text);
    }

    public void EndEditingName() {
        if (inputName.text == "") {
            inputName.text = Random.Range(19, 39).ToString();
            PlayerPrefs.SetString("PlayerName", inputName.text);
        }

        GameObject.Find("NamePanel").SetActive(false);
        lobbyNetwork.AddNickName(PlayerPrefs.GetString("PlayerName"));
    }
}
