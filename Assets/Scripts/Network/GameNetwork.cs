using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameNetwork : MonoBehaviourPunCallbacks
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Menu");
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
