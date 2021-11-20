using UnityEngine;
using UnityEngine.UI;

public class JoiningRoomText : MonoBehaviour {
    public GameObject RoomName;
    private Text roomNameText;

    private void Start() {
        roomNameText = RoomName.GetComponent<Text>();
    }

    public void WriteRoomName(string roomName) {
        roomNameText.text = $"Room: {roomName}";
    }
}
