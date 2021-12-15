using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform Content;
    [SerializeField] private GameObject RoomListing;



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for(int i = 0; i<Content.childCount; i++)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
        foreach(RoomInfo info in roomList)
        {
            if (info.PlayerCount == 0) continue;

            GameObject listing = Instantiate(RoomListing, Content);
            if(listing != null)
            {
                listing.GetComponent<RoomListing>().SetRoomInfo(info);
            }
        }
    }
}
