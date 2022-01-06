using UnityEngine;
using Photon.Pun;

public class LifeManager : MonoBehaviour {
    private GameObject Player;
    private PlayerHP playerHP;
    private ManaPlayer manaPlayer;
    private PlayerHPText playerHPText;

    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private GameObject scoreTextObject;
    private Transform spawnPoint;

    private PhotonView photonView;
    public GameObject GameNetworkManager;
    private GameNetwork gameNetwork;
    private ScoreText scoreText;

    private TurningDeathStatus deathStatus;
    public bool IsEndGame = false;

    public void Init(GameObject player) {
        deathStatus = GetComponent<TurningDeathStatus>();
        photonView = GetComponent<PhotonView>();
        gameNetwork = GameNetworkManager.GetComponent<GameNetwork>();
        spawnPoint = gameNetwork.SpawnPosition;

        Player = player;
        playerHP = Player.GetComponent<PlayerHP>();
        manaPlayer = Player.GetComponent<ManaPlayer>();
        playerHPText = Player.GetComponent<PlayerHPText>();
        scoreText = scoreTextObject.GetComponent<ScoreText>();
    }

    public void EndLife() {
        Debug.Log("EndLife");
        playerHP.ResetHealth();
        playerHPText.ChangeHealthText();
        TeleportToSpawnPoint();
    }

    private void TeleportToSpawnPoint() {
        Player.transform.position = spawnPoint.position;
        Player.transform.rotation = spawnPoint.rotation;
    }

    public void EndGameForPlayer() {
        Debug.Log("Smert'");
        deathStatus.TurnOnDeathStatus(gameNetwork);
        gameNetwork.UpdateTeamsPanel();
        if (gameNetwork.IsFirstTeam) {
            CheckEndGame(gameNetwork.LifesForFirstTeam, gameNetwork.IsFirstTeam);
        } else {
            CheckEndGame(gameNetwork.LifesForSecondTeam, gameNetwork.IsFirstTeam);
        }
    }

    public void CheckEndGame(float LifesForTeam, bool IsFirstTeam) {
        Debug.Log(IsFirstTeam);
        if (IsFirstTeam) {
            photonView.RPC("MakeLossForTeam", RpcTarget.All, IsFirstTeam);
        } else {
            photonView.RPC("MakeLossForTeam", RpcTarget.All, !IsFirstTeam);
        }
        if (gameNetwork.AmountOfLosses == LifesForTeam) {
            EndGame(IsLosingTeam: true);
        }
    }

    [PunRPC]
    public void MakeLossForTeam(bool IsLosingTeam) {
        if (IsLosingTeam) {
            gameNetwork.AmountOfLosses++;
        }
    }

    public void EndGame(bool IsLosingTeam) {
        Debug.Log("EndGame");
        IsEndGame = true;
        if (IsLosingTeam) {
            if (!gameNetwork.IsFirstTeam) {
                photonView.RPC("WinFirstTeam", RpcTarget.All);
            } else {
                photonView.RPC("WinSecondTeam", RpcTarget.All);
            }
        } else {
            if (gameNetwork.IsFirstTeam) {
                photonView.RPC("WinFirstTeam", RpcTarget.All);
            } else {
                photonView.RPC("WinSecondTeam", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    public void WinFirstTeam() {
        gameUI.SetActive(false);
        endGameUI.SetActive(true);
        if (gameNetwork.IsFirstTeam) {
            endGameUI.GetComponent<EndGameCanvasManager>().MakeWinText();
            scoreText.SaveScore();
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
            scoreText.SaveScore();
        } else {
            endGameUI.GetComponent<EndGameCanvasManager>().MakeLoseText();
        }
        manaPlayer.DestroyToAvoidExceptions();
    }
}
