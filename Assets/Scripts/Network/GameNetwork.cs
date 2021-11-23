using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;

public class GameNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject SpawnPosition1;
    [SerializeField] private GameObject SpawnPosition2;
    [SerializeField] private GameObject SpawnPosition3;
    [SerializeField] private GameObject SpawnPosition4;
    [SerializeField] private GameObject SpawnPosition5;
    [SerializeField] private GameObject SpawnPosition6;
    void Start()
    {
        List<GameObject> SpawnPositions = new List<GameObject>() 
        { SpawnPosition1, SpawnPosition2, SpawnPosition3,
        SpawnPosition4, SpawnPosition5, SpawnPosition6 };
        GameObject SpawnPosition = null;

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) {
            if (PhotonNetwork.PlayerList[i].NickName == PhotonNetwork.NickName) {
                SpawnPosition = SpawnPositions[i];
                print(SpawnPositions[i].name);
                break;
            }
        }
        GameObject Player = PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        Player.name += PhotonNetwork.CountOfPlayers.ToString() ;
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
