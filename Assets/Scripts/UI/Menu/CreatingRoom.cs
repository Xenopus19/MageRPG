using UnityEngine;

public class CreatingRoom : MonoBehaviour {
    public GameObject roomButtons;
    public GameObject lobbyNetworkManager;
    public GameObject roomTextObject;

    private LobbyNetwork lobbyNetwork;
    private RoomText roomText;

    private void Init() {
        lobbyNetwork = lobbyNetworkManager.GetComponent<LobbyNetwork>();
        roomText = roomTextObject.GetComponent<RoomText>();
    }

    public void CreateRoomPanel() {
        Init();
        string playerName = PlayerPrefs.GetString("PlayerName");
        string randomRoomName = $"{playerName}{Random.Range(1000, 9999)}";
        lobbyNetwork.CreateRoom(randomRoomName);
        roomText.ChangeRoomText(randomRoomName);

        gameObject.SetActive(true);
        roomButtons.SetActive(false);
    }

    

    public void Cancel() {
        roomButtons.SetActive(true);
        gameObject.SetActive(false);
    }
}
