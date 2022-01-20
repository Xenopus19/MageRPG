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
    public ScoreText scoreText;

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

    public void EndLife(int PlayerID) {
        Debug.Log("EndLife");
        playerHP.ResetHealth();
        playerHPText.ChangeHealthText();
        photonView.RPC("TeleportToSpawnPoint", RpcTarget.All, PlayerID);
    }
    [PunRPC]
    public void TeleportToSpawnPoint(int PlayerID) 
    {

        Debug.LogWarning("RPC called");
        Player = PhotonView.Find(PlayerID).gameObject;
        Debug.LogWarning(Player.name);
        Player.GetComponent<PlayerMovement>().TeleportPlayer(spawnPoint.position);
        //Player.transform.position = spawnPoint.position;
        //Player.transform.rotation = spawnPoint.rotation;
    }

    public void EndGameForPlayer() {
        Debug.Log("Smert");
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
        if (IsLosingTeam) {
            if (!gameNetwork.IsFirstTeam) {
                Debug.Log("Win1");
                photonView.RPC("WinFirstTeam", RpcTarget.All);
            } else {
                photonView.RPC("WinSecondTeam", RpcTarget.All);
            }
        } else {
            if (gameNetwork.IsFirstTeam) {
                Debug.Log("Win1");
                IsEndGame = true;photonView.RPC("WinFirstTeam", RpcTarget.All);
            } else {
                photonView.RPC("WinSecondTeam", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    public void WinFirstTeam() {
        IsEndGame = true;
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
        IsEndGame = true;
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
