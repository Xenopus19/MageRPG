using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text text;

    private string RoomName;

    public void SetRoomInfo(RoomInfo info)
    {
        text.text += info.Name + " " + info.PlayerCount + "/" + info.MaxPlayers;
        RoomName = info.Name;
    }

    public void JoinRoom()
    {
        if(RoomName!=null)
        PhotonNetwork.JoinRoom(RoomName);
    }
}
