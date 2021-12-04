using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;

public class GameNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();
    public Transform SpawnPosition;
    public bool IsFirstTeam { get; private set; }
    void Start()
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) {
            if (PhotonNetwork.PlayerList[i].NickName == PhotonNetwork.NickName) {
                SpawnPosition = SpawnPositions[i].transform;
                IsFirstTeam = i % 2 == 0;
                break;
            }
        }
        GameObject Player = PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPosition.position, SpawnPosition.rotation);
        Player.name += PhotonNetwork.CountOfPlayers.ToString();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("NetworkLobby");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined the room.");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " left the room.");
    }
}
