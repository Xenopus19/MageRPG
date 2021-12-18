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
        int MaxPlayers = info.MaxPlayers - 1;
        text.text += info.Name + " " + info.PlayerCount + "/" + MaxPlayers;
        RoomName = info.Name;
    }

    public void JoinRoom()
    {
        if(RoomName!=null)
        PhotonNetwork.JoinRoom(RoomName);
    }
}
