using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform Content;
    [SerializeField] private GameObject RoomListing;

    private void Start()
    {
        Debug.LogWarning(PhotonNetwork.InLobby);
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.LogError("Callback called");
        foreach(RoomInfo info in roomList)
        {
            GameObject listing = Instantiate(RoomListing, Content);
            if(listing != null)
            {
                listing.GetComponent<RoomListing>().SetRoomInfo(info);
            }
        }
    }
}
