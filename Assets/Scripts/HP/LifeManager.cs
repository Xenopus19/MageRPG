using UnityEngine;
using Photon.Pun;

public class LifeManager : MonoBehaviour {
    private GameObject Player;
    private PlayerHP playerHP;
    private ManaPlayer manaPlayer;
    private PlayerHPText playerHPText;

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
        playerHPText = Player.GetComponent<PlayerHPText>();
    }

    public void EndLife() {
        Debug.LogWarning("EndLife");
        playerHP.CurrentHealth = playerHP.MaxHealth;
        playerHPText.ChangeHealthText();
        TeleportToSpawnPoint();
    }

    private void TeleportToSpawnPoint() {
        Player.transform.position = spawnPoint.position;
        Player.transform.rotation = spawnPoint.rotation;
    }

    public void EndGameForPlayer() {
        if (gameNetwork.IsFirstTeam) {
           photonView.RPC("MakeLossForTeam", RpcTarget.All, gameNetwork.IsFirstTeam);
            if (gameNetwork.AmountOfLosses == gameNetwork.LifesForFirstTeam) {
                EndGame();
            }
        } else {
           photonView.RPC("MakeLossForTeam", RpcTarget.All, !gameNetwork.IsFirstTeam);
            if (gameNetwork.AmountOfLosses == gameNetwork.LifesForSecondTeam) {
                EndGame();
            }
        }
    }

    [PunRPC]
    public void MakeLossForTeam(bool IsLosingTeam) {
        if (IsLosingTeam) {
            gameNetwork.AmountOfLosses++;
        }
    }

    private void EndGame() {
        Debug.LogWarning("EndGame");
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
