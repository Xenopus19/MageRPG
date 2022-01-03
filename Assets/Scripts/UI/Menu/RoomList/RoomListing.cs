using Photon.Realtime;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text text;

    public RoomInfo roomInfo;

    public void SetRoomInfo(RoomInfo info)
    {
        int MaxPlayers = info.MaxPlayers - 1;
        text.text = info.Name + " " + info.PlayerCount + "/" + MaxPlayers;
        roomInfo = info;
    }

    public void JoinRoom()
    {
        if(roomInfo!=null)
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }

    private void Update()
    {
        if (roomInfo.MaxPlayers <= 0)
            Destroy(gameObject);
    }
}
