using UnityEngine;
using Photon.Pun;
using System;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public string playerName;

    public GameObject playerAmountTextCR;
    public GameObject playerAmountTextJR;
    private PlayerAmountText playerAmountTextcr;
    private PlayerAmountText playerAmountTextjr;

    public GameObject joiningRoom;
    private JoiningRoomText joiningRoomText;
    private void Start()
    {
        playerName = PhotonNetwork.NickName;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";

        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.ConnectUsingSettings();
        }

        playerAmountTextcr = playerAmountTextCR.GetComponent<PlayerAmountText>();
        playerAmountTextjr = playerAmountTextJR.GetComponent<PlayerAmountText>();
        joiningRoomText = joiningRoom.GetComponent<JoiningRoomText>();
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

    public void CreateRoom(string nameOfRoom) {
        PhotonNetwork.CreateRoom(nameOfRoom, new Photon.Realtime.RoomOptions { MaxPlayers = 6 });
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined the room");
        joiningRoomText.WriteRoomName(PhotonNetwork.CurrentRoom?.Name.ToString());
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    } 
    
    public override void OnLeftRoom() {
        PhotonNetwork.LoadLevel("NetworkLobby");
    }

    public void LoadLevel() {
        PhotonNetwork.LoadLevel("Arena2");
    }

    private void Update() {
        playerAmountTextcr?.ChangePlayerAmountText(PhotonNetwork.CurrentRoom?.PlayerCount.ToString());
        playerAmountTextjr?.ChangePlayerAmountText(PhotonNetwork.CurrentRoom?.PlayerCount.ToString());
        //if (PhotonNetwork.CurrentRoom?.PlayerCount == PhotonNetwork.CurrentRoom?.MaxPlayers) {
        //    LoadLevel();
        //}
    }

    //public void CreateRoom()
    //{
    //    PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 2 });
    //}

    //public override void OnJoinedRoom() 
    //{
    //    Debug.Log("Joined the room.");

    //    PhotonNetwork.LoadLevel("Arena2");
    //}
}
