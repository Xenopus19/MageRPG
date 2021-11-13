using UnityEngine;
using Photon.Pun;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public string playerName;
    private void Start()
    {
        //PhotonNetwork.NickName = "Player " + Random.Range(19, 39);
        playerName = PhotonNetwork.NickName;
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

    public void CreateRoom(string nameOfRoom)
    {
        PhotonNetwork.CreateRoom(nameOfRoom, new Photon.Realtime.RoomOptions {MaxPlayers = 2 });
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
