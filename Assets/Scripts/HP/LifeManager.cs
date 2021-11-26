using UnityEngine;
using Photon.Pun;

public class LifeManager : MonoBehaviour {
    private GameObject Player;
    private PlayerHP playerHP;
    private ManaPlayer manaPlayer;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endGameUI;
    private Transform spawnPoint;

    private PhotonView photonView;
    public GameObject GameNetworkManager;
    private GameNetwork gameNetwork;

    public void Init(GameObject player) {
        photonView = gameObject.GetComponent<PhotonView>();
        gameNetwork = GameNetworkManager.GetComponent<GameNetwork>();
        spawnPoint = gameNetwork.SpawnPosition;

        Player = player;
        playerHP = Player.GetComponent<PlayerHP>();
        manaPlayer = Player.GetComponent<ManaPlayer>();
    }

    public void EndLife() {
        playerHP.CurrentHealth = playerHP.MaxHealth;
        TeleportToSpawnPoint();
    }

    private void TeleportToSpawnPoint() {
        Player.transform.position = spawnPoint.position;
        Player.transform.rotation = spawnPoint.rotation;
    }

    public void EndGame() {
        if (!gameNetwork.IsFirstTeam) {
            photonView.RPC("WinFirstTeam", RpcTarget.All);
        } else {
            photonView.RPC("WinSecondTeam", RpcTarget.All);
        }
    }

    [PunRPC]
    public void WinFirstTeam() {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        if (gameNetwork.IsFirstTeam) {
            endGameUI.GetComponent<EndGameCanvasManager>().MakeWinText();
        } else {
            endGameUI.GetComponent<EndGameCanvasManager>().MakeLoseText();
        }
        manaPlayer.DestroyToAvoidExceptions();
    }

    [PunRPC]
    public void WinSecondTeam() {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        if (!gameNetwork.IsFirstTeam) {
            endGameUI.GetComponent<EndGameCanvasManager>().MakeWinText();
        } else {
            endGameUI.GetComponent<EndGameCanvasManager>().MakeLoseText();
        }
        manaPlayer.DestroyToAvoidExceptions();
    }
}
