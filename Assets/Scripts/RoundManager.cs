using UnityEngine;
using Photon.Pun;

public class RoundManager : MonoBehaviour {
    private GameObject Player;
    private PlayerHP playerHP;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject spawnPoint;

    private PhotonView photonView;

    public void Init(GameObject player) {
        photonView = gameObject.GetComponent<PhotonView>();
        Player = player;
        playerHP = Player.GetComponent<PlayerHP>();
    }

    public void EndRound() {
        playerHP.CurrentHealth = playerHP.MaxHealth;
        Player.transform.position = spawnPoint.transform.position;
    }

    
    public void EndGameByLosing() {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        endGameUI.GetComponent<EndGameCanvasManager>().MakeLoseText();
        photonView.RPC("EndGameByWinning", RpcTarget.Others);
    }
    [PunRPC]
    public void EndGameByWinning() {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        
        endGameUI.GetComponent<EndGameCanvasManager>().MakeWinText();
    }
}
