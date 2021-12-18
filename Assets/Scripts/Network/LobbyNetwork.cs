using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public string playerName;

    public GameObject playerAmountTextCR;
    public GameObject playerAmountTextJR;
    private PlayerAmountText playerAmountText;

    public GameObject joiningRoom;
    public GameObject roomList;

    private JoiningRoomText joiningRoomText;
    private GameObject LoadingPlane;
    private TypedLobby defaultLobby = new TypedLobby("default", LobbyType.Default);
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
        JoinDefaultLobby();
    }
    private void JoinDefaultLobby()
    {
        Debug.Log(PhotonNetwork.JoinLobby(defaultLobby));
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
        if (PhotonNetwork.CurrentRoom.Name == "CallbackTrigger") return;
        Debug.Log("Joined the room");
        roomList.SetActive(false);
        joiningRoom.GetComponent<JoiningRoom>().CreateJoinRoomPanel();
        if (!PhotonNetwork.IsMasterClient) 
        {
            //joiningRoomText.WriteRoomName(PhotonNetwork.CurrentRoom?.Name);
            playerAmountText = playerAmountTextJR.GetComponent<PlayerAmountText>(); 
        }
        
        else 
        {
            //playerAmountText = playerAmountTextCR.GetComponent<PlayerAmountText>();
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
    }
}
