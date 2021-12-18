using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class JoiningRoomText : MonoBehaviour {
    public GameObject RoomName;
    private Text roomNameText;

    private void Start() {
        roomNameText = RoomName.GetComponent<Text>();
    }

    public void WriteRoomName() 
    {
        roomNameText.text = $"Room: " + PhotonNetwork.CurrentRoom.Name ;
    }
}
