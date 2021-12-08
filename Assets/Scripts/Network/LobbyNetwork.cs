using UnityEngine;
using Photon.Pun;
using System;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public string playerName;

    public GameObject playerAmountTextCR;
    public GameObject playerAmountTextJR;
    private PlayerAmountText playerAmountText;

    public GameObject joiningRoom;
    private JoiningRoomText joiningRoomText;
    private GameObject LoadingPlane;
    private void Start()
    {
        playerName = PhotonNetwork.NickName;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";

        LoadingPlane = GameObject.Find("LoadingPanel");

        if (!PhotonNetwork.IsConnected) 
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            LoadingPlane.SetActive(false);
        }

        joiningRoomText = joiningRoom.GetComponent<JoiningRoomText>();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master.");
        LoadingPlane.SetActive(false);
    }

    public void AddNickName(string name) 
    {
        PhotonNetwork.NickName = name;
        Debug.Log("Player is " + PhotonNetwork.NickName);
    }

    public void CreateRoom(string nameOfRoom) 
    {
        PhotonNetwork.CreateRoom(nameOfRoom, new Photon.Realtime.RoomOptions { MaxPlayers = 7 });
    }

    public void JoinRoom() 
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom() 
    {
        Debug.Log("Joined the room");
        if (!PhotonNetwork.IsMasterClient) {
            joiningRoomText.WriteRoomName(PhotonNetwork.CurrentRoom?.Name.ToString());
            playerAmountText = playerAmountTextJR.GetComponent<PlayerAmountText>(); 
        } else {
            playerAmountText = playerAmountTextCR.GetComponent<PlayerAmountText>();
        }
    }

    public void LeaveRoom() 
    {
        PhotonNetwork.LeaveRoom();
    } 
    
    public override void OnLeftRoom() 
    {
        PhotonNetwork.LoadLevel("NetworkLobby");
    }

    public void LeaveLobby() 
    {
        PhotonNetwork.LeaveLobby();
    }

    public override void OnLeftLobby() 
    {
        PhotonNetwork.LoadLevel("Menu");
    }

    public void LoadLevel() 
    {
        PhotonNetwork.CurrentRoom.IsVisible = false;
        LoadingPlane.SetActive(true);
        PhotonNetwork.LoadLevel("Arena3");
    }

    private void Update() 
    {
        playerAmountText?.ChangePlayerAmountText(PhotonNetwork.CurrentRoom?.PlayerCount.ToString());
        if (PhotonNetwork.CurrentRoom?.PlayerCount == PhotonNetwork.CurrentRoom?.MaxPlayers && PhotonNetwork.CurrentRoom != null) {
            LoadLevel();
            Destroy(gameObject);
        }
    }

    /*public void CreateRoom()     NANI?
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 2 });
    }

    public override void OnJoinedRoom() 
    {
        Debug.Log("Joined the room.");

        PhotonNetwork.LoadLevel("Arena2");
    }*/
}
