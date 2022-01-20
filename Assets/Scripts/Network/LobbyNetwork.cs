using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine.SceneManagement;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    public string playerName;

    public GameObject playerAmountTextCR;
    public GameObject playerAmountTextJR;
    private PlayerAmountText playerAmountText;

    public GameObject joiningRoom;
    public GameObject roomList;

    public GameObject creatingRoomPanel;
    private CreatingRoom creatingRoom;
    public GameObject startButton;

    private JoiningRoomText joiningRoomText;
    private GameObject LoadingPlane;
    private TypedLobby defaultLobby = new TypedLobby("default", LobbyType.Default);

    public GameObject ChoosingMapObject;
    private ChoosingMap choosingMap;
    private void Start()
    {
        //Debug.LogError("In lobby: " + PhotonNetwork.InLobby);
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;

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
            //Debug.LogError("Is connected to master");
            JoinDefaultLobby();
            LoadingPlane.SetActive(false);
        }

        creatingRoom = creatingRoomPanel.GetComponent<CreatingRoom>();
        joiningRoomText = joiningRoom.GetComponent<JoiningRoomText>();
        choosingMap = ChoosingMapObject.GetComponent<ChoosingMap>();
    }

    

    public override void OnConnectedToMaster()
    {
        //Debug.Log("Connected to master.");
        LoadingPlane.SetActive(false);
        JoinDefaultLobby();
    }
    private void JoinDefaultLobby()
    {
        //Debug.LogError("Joined lobby");
        PhotonNetwork.JoinLobby(defaultLobby);
    }

    private IEnumerable JoinDefaultLobbyWithDelay()
    {
        yield return new WaitForSeconds(0.5f);

        JoinDefaultLobby();
    }

    public void AddNickName(string name) 
    {
        PhotonNetwork.NickName = name;
        //Debug.Log("Player is " + PhotonNetwork.NickName);
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
        roomList.SetActive(false);
        joiningRoom.GetComponent<JoiningRoom>().CreateJoinRoomPanel();
        if (!PhotonNetwork.IsMasterClient) 
        {
            joiningRoomText.WriteRoomName();
            playerAmountText = playerAmountTextJR.GetComponent<PlayerAmountText>(); 
        }
        
        else 
        {
            playerAmountText = playerAmountTextCR.GetComponent<PlayerAmountText>();
        }
        
        if (PhotonNetwork.CountOfPlayers == 6) 
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }
    }

    public void LeaveRoom() 
    {
        photonView.RPC("MakeMaster", RpcTarget.All);
        PhotonNetwork.LeaveRoom();
    } 
    
    public override void OnLeftRoom() 
    {
        PhotonNetwork.LoadLevel("NetworkLobby");

        LeaveLobby();
    }
    
    [PunRPC]
    private void MakeMaster() 
    {
        if (PhotonNetwork.PlayerList.Length > 1) 
        {
            if (PhotonNetwork.PlayerList[1].NickName == PhotonNetwork.NickName) 
            {
                print("master");
                creatingRoom.MakeMasterRoomPanel(PhotonNetwork.CurrentRoom.Name);
                playerAmountText = playerAmountTextCR.GetComponent<PlayerAmountText>();
            }
        }
    }

    public void LeaveLobby() 
    {
        if (PhotonNetwork.InLobby)
        {
            Debug.LogError("Left lobby");
            PhotonNetwork.LeaveLobby();
        }
    }

    public void ReturnToMenu()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        LeaveLobby();
        PhotonNetwork.LoadLevel("Menu");
        //PhotonNetwork.LoadLevel("Menu");
    }

    public override void OnLeftLobby() 
    {
        
    }

    public void LoadLevel() 
    {
        PhotonNetwork.CurrentRoom.IsVisible = false;
        photonView.RPC("MakeLoadingPanel", RpcTarget.All);

        PhotonNetwork.LoadLevel($"{choosingMap.mapName}");
    }

    [PunRPC]
    public void MakeLoadingPanel() {
        LoadingPlane.SetActive(true);
    }

    private void Update() 
    {
        playerAmountText?.ChangePlayerAmountText(PhotonNetwork.CurrentRoom?.PlayerCount.ToString());
        if (PhotonNetwork.CurrentRoom?.PlayerCount % 2 == 0 || PhotonNetwork.CurrentRoom?.PlayerCount == 1) {
            startButton.SetActive(true);
        } else {
            startButton.SetActive(false);
        }
    }
}
