using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject SpawnPosition;
    void Start()
    {
        GameObject Player = PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPosition.transform.position, Quaternion.identity);
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
