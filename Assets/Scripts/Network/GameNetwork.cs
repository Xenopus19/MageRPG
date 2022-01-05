using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine.UI;

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

    [SerializeField] private GameObject LifeManagerObject;
    public LifeManager lifeManager;
    private GameObject PlayerObject;
    private PhotonView _photonView;
    void Start() 
    {
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
        Debug.LogWarning("DefineNickNamesStart");
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
        Debug.Log("DefineNickName");
    }

    //public void UpdateTeamsPanel() {
    //    Debug.Log("UpdateTeamsPanel");
    //    PhotonNetwork.NickName += " (Dead)";
    //    _photonView.RPC("DefineNickName", RpcTarget.All);
    //}

    private void FindGone() {
        Debug.LogWarning("FindGoneStart");
        for (int i = 0; i < Players.Length; i++) {
            string nickname = Players[i].NickName;
            for (int j = 0; j < PhotonNetwork.PlayerList.Length; j++) {
                if (PhotonNetwork.PlayerList[j].NickName == nickname) {
                    break;
                }
                if (j + 1 == PhotonNetwork.PlayerList.Length) {
                    Players[i].NickName += " (Dead)";
                    if (IsFirstTeam && i % 2 == 0) {
                        lifeManager.CheckEndGame(AmountOfLosses, LifesForFirstTeam, IsFirstTeam);
                    } else if (!IsFirstTeam && i % 2 == 1) {
                        lifeManager.CheckEndGame(AmountOfLosses, LifesForSecondTeam, IsFirstTeam);
                    }
                }
            }
        }
        Debug.LogWarning("FindGoneEnd");
    }

    public void LeaveRoom() {
        //if (!lifeManager.IsDead) {
        //    Debug.Log("LeaveRoom");
        //    //lifeManager.EndGameForPlayer();
        //}
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {
        SceneManager.LoadScene("NetworkLobby");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        Debug.Log(newPlayer.NickName + " joined the room.");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        Debug.Log(otherPlayer.NickName + " left the room.");
        FindGone();
        _photonView.RPC("DefineNickName", RpcTarget.All);
    }

    public void OnDie() {
        GameObject DeadPlayer = PhotonNetwork.Instantiate(DeadPlayerPrefab.name, PlayerObject.transform.position, PlayerObject.transform.rotation);
        PhotonNetwork.Destroy(PlayerObject);
    }
}
