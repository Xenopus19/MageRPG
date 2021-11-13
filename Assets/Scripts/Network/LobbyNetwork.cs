using UnityEngine;
using Photon.Pun;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        //PhotonNetwork.NickName = "Player " + Random.Range(19, 39);

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master.");
        GameObject.Find("LoadingPanel").SetActive(false);
    }

    public void AddNickName(string name) 
    {
        PhotonNetwork.NickName = name;
        Debug.Log("Player is " + PhotonNetwork.NickName);
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 2 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room.");

        PhotonNetwork.LoadLevel("Arena2");
    }
}
