using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class JoiningRoomText : MonoBehaviour {
    public GameObject RoomName;
    private Text roomNameText;

    public void Init() {
        roomNameText = RoomName.GetComponent<Text>();
    }

    public void WriteRoomName() 
    {
        roomNameText = RoomName.GetComponent<Text>();
        roomNameText.text = $"Room: " + PhotonNetwork.CurrentRoom.Name ;
    }
}
