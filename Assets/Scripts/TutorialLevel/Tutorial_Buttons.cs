using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Tutorial_Buttons : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
        PhotonNetwork.LeaveRoom();
    }
}
