using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameNetwork : MonoBehaviourPunCallbacks {
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject DeadPlayerPrefab;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();
    [SerializeField] private List<GameObject> NickNameTexts = new List<GameObject>();
    public Transform SpawnPosition;
    public bool IsFirstTeam { get; private set; }
    public float LifesForFirstTeam = 0;
    public float LifesForSecondTeam = 0;
    public float AmountOfLosses = 0;
    private Photon.Realtime.Player[] Players;
    private List<int> IndexDeadPlayers = new List<int>() { -1 };

    [SerializeField] private GameObject LifeManagerObject;
    public LifeManager lifeManager;
    private GameObject PlayerObject;
    private PhotonView _photonView;

    [SerializeField] private GameObject LoadingPanel;
    void Start() 
    {
        Debug.Log($"{PhotonNetwork.PlayerList.Length} {PhotonNetwork.CurrentRoom.PlayerCount}");
        if (PhotonNetwork.PlayerList.Length != PhotonNetwork.CurrentRoom.PlayerCount) {
            LoadingPanel.SetActive(true);
        } else {
            LoadingPanel.SetActive(false);
        }
        lifeManager = LifeManagerObject.GetComponent<LifeManager>();
        Players = PhotonNetwork.PlayerList;
        MakeNickNamesDifferent();
        DefineTeam();
        DefineNickName();
        PlayerObject = PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPosition.position, SpawnPosition.rotation);
        PhotonNetwork.LocalPlayer.TagObject = PlayerObject;
        PlayerObject.GetComponent<PlayerNetwork>().team = IsFirstTeam;
        PlayerObject.GetComponent<AboveObjectHPBar>().InFirstTeam = IsFirstTeam;
        PlayerObject.name += SpawnPosition.name;
        _photonView = GetComponent<PhotonView>();
    }

    private void MakeNickNamesDifferent() {
        string nickName;
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) {
            nickName = PhotonNetwork.PlayerList[i].NickName;
            for (int j = 0; j < PhotonNetwork.PlayerList.Length; j++) {
                if (nickName == PhotonNetwork.PlayerList[j].NickName && i != j) {
                    PhotonNetwork.PlayerList[j].NickName += "1";
                }
            }
        }
    }

    private void DefineTeam() {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) {
            if (i % 2 == 0) {
                LifesForFirstTeam++;
            } else {
                LifesForSecondTeam++;
            }
            if (PhotonNetwork.PlayerList[i].NickName == PhotonNetwork.NickName) {
                SpawnPosition = SpawnPositions[i].transform;
                IsFirstTeam = i % 2 == 0;
                continue;
            }
        }
    }

    [PunRPC]
    public void DefineNickName() {
        Text nickName;
        for (int i = 0; i < Players.Length; i++) {
            if (IsFirstTeam) {
                nickName = NickNameTexts[i].GetComponent<Text>();
                nickName.text = Players[i].NickName;
                continue;
            } else {
                if (i % 2 == 1) {
                    nickName = NickNameTexts[i - 1].GetComponent<Text>();
                    nickName.text = Players[i].NickName;
                    continue;
                } else {
                    nickName = NickNameTexts[i + 1].GetComponent<Text>();
                    nickName.text = Players[i].NickName;
                    continue;
                }

            }
        }
    }

    public void UpdateTeamsPanel() {
        PhotonNetwork.NickName += " (Dead)";
        for (int i = 0; i < Players.Length; i++) {
            if (PhotonNetwork.NickName == Players[i].NickName) {
                IndexDeadPlayers.Add(i);
            }
        }
        _photonView.RPC("DefineNickName", RpcTarget.All);
    }

    private void FindGone() {
        for (int i = 0; i < Players.Length; i++) {
            string nickname = Players[i].NickName;
            for (int j = 0; j < PhotonNetwork.PlayerList.Length; j++) {
                if (PhotonNetwork.PlayerList[j].NickName == nickname) {
                    break;
                }
                if (j + 1 == PhotonNetwork.PlayerList.Length) {
                    for (int k = 0; k < IndexDeadPlayers.Count; k++) {
                        if (i == IndexDeadPlayers[k]) {
                            break;
                        } if (k + 1 == IndexDeadPlayers.Count) {
                            Players[i].NickName += " (Dead)";
                            IndexDeadPlayers.Add(i);
                        }
                    }
                    for (int k = 0, amountOfEven = 0, amountOfOdd = -1; k < IndexDeadPlayers.Count; k++) {
                        if (IndexDeadPlayers[k] % 2 == 0) {
                            amountOfEven++;
                        } else {
                            amountOfOdd++;
                        }
                        if (k + 1 == IndexDeadPlayers.Count && (amountOfEven == Players.Length / 2 || amountOfOdd == Players.Length / 2)) {
                            Debug.Log("EndGameInFor");
                            lifeManager.EndGame(IsLosingTeam: false);
                        }
                    }
                    if (IsFirstTeam && i % 2 == 0) {
                        lifeManager.CheckEndGame(LifesForFirstTeam, IsFirstTeam);
                    } else if (!IsFirstTeam && i % 2 == 1) {
                        lifeManager.CheckEndGame(LifesForSecondTeam, IsFirstTeam);
                    }
                }
            }
        }
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {
        SceneManager.LoadScene("NetworkLobby");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log(newPlayer.NickName + " joined the room.");
        if (PhotonNetwork.PlayerList.Length != PhotonNetwork.CurrentRoom.PlayerCount) {
            LoadingPanel.SetActive(true);
        } else {
            LoadingPanel.SetActive(false);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.Log(otherPlayer.NickName + " left the room.");
        Debug.Log($"OnLeft {lifeManager.IsEndGame}");
        if (!lifeManager.IsEndGame) {
            FindGone();
            _photonView.RPC("DefineNickName", RpcTarget.All);
        }
    }

    public void OnDie() {
        GameObject DeadPlayer = PhotonNetwork.Instantiate(DeadPlayerPrefab.name, PlayerObject.transform.position, PlayerObject.transform.rotation);
        PhotonNetwork.Destroy(PlayerObject);
    }
}
