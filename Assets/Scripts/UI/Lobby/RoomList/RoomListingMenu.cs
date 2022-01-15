using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform Content;
    [SerializeField] private GameObject RoomButtonPrefab;

    private Dictionary<string, GameObject> roomButtons = new Dictionary<string, GameObject>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.LogError("Room list updated");
        if(roomList.Count!=0)
        foreach(RoomInfo info in roomList)
        {
            if(roomButtons.ContainsKey(info.Name))
            {
                if(info.RemovedFromList)
                {
                    DeleteRoomButton(info);
                }
                else
                {
                    roomButtons[info.Name].GetComponent<RoomListing>().SetRoomInfo(info);
                }
            }
            else
            {
                CreateNewRoomButton(info);
            }
        }
    }
    private void DeleteRoomButton(RoomInfo info)
    {
        Destroy(roomButtons[info.Name]);
        roomButtons.Remove(info.Name);
    }

    private void CreateNewRoomButton(RoomInfo info)
    {
        GameObject roomListingButton = Instantiate(RoomButtonPrefab, Content.transform);
        roomListingButton.GetComponent<RoomListing>().SetRoomInfo(info);
        roomButtons.Add(info.Name, roomListingButton);
    }
}
