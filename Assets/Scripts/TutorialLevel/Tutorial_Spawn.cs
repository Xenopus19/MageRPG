using Photon.Pun;
using UnityEngine;

public class Tutorial_Spawn : MonoBehaviourPunCallbacks
{
    [Header("Spawn Preferences")]
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private Transform SpawnPoint;

    [Header("UI Elements")]
    [SerializeField] private GameObject LoadingScreen;

    private void Start()
    {
        PhotonNetwork.NickName = Random.Range(19, 3919).ToString();
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";

        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            LoadLevel();
        }     
    }

    private void LoadLevel()
    {
        PhotonNetwork.CreateRoom("tutorial");
        LoadingScreen.SetActive(false);
    }    

    public override void OnConnectedToMaster()
    {
        LoadLevel();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPoint.position, Quaternion.identity);
    }
}

