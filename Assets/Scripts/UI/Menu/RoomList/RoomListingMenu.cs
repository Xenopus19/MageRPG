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
            Debug.Log(Content.GetChild(i).gameObject.name);
            Destroy(Content.GetChild(i).gameObject);
        }
        for(int i = 0; i<roomList.Count; i++)
        {
            if (roomList[i].PlayerCount <=0) continue;
            Debug.LogWarning(roomList[i].Name);
            GameObject listing = Instantiate(RoomListing, Content);
            if(listing != null)
            {
                listing.GetComponent<RoomListing>().SetRoomInfo(roomList[i]);
            }
        }
    }
}
