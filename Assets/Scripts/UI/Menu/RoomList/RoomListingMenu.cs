using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform Content;
    [SerializeField] private GameObject RoomListing;

    private List<RoomListing> listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            if(info.RemovedFromList)
            {
                int index = listings.FindIndex(x => x.roomInfo.Name == info.Name);
                if(index!=-1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            GameObject roomButton = Instantiate(RoomListing, Content);
            if(roomButton != null)
            {
                RoomListing thisListing = roomButton.GetComponent<RoomListing>();
                thisListing.SetRoomInfo(info);
                listings.Add(thisListing);
                Debug.LogWarning("Created: " + roomButton.GetComponent<RoomListing>().roomInfo.Name);
            }
        }
    }
}
