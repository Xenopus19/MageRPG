using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text text;

    public void SetRoomInfo(RoomInfo info)
    {
        text.text += info.Name + " " + info.PlayerCount + "/" + info.MaxPlayers;
    }
}
