using UnityEngine; 
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private GameObject DeadPlayerPrefab;
    [SerializeField] private List<GameObject> SpawnPositions = new List<GameObject>();
    [SerializeField] private List<GameObject> NickNameTexts = new List<GameObject>();
    public Transform SpawnPosition;
    public bool IsFirstTeam { get; private set; }
    public float LifesForFirstTeam = 0;
    public float LifesForSecondTeam = 0;
    public float AmountOfLosses = 0;

    private GameObject PlayerGO;
    void Start() 
    {
        MakeNickNamesDifferent();
        DefineTeam();
        DefineNickName();
        PlayerGO = PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPosition.position, SpawnPosition.rotation);
        PhotonNetwork.LocalPlayer.TagObject = PlayerGO;
        PlayerGO.GetComponent<PlayerNetwork>().team = IsFirstTeam;
        PlayerGO.GetComponent<AboveObjectHPBar>().InFirstTeam = IsFirstTeam;
        PlayerGO.name += SpawnPosition.name;
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

    private void DefineNickName() {
        Text nickName;
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++) {
            if (IsFirstTeam) {
                nickName = NickNameTexts[i].GetComponent<Text>();
                nickName.text = PhotonNetwork.PlayerList[i].NickName;
                continue;
            } else {
                if (i % 2 == 1) {
                    nickName = NickNameTexts[i - 1].GetComponent<Text>();
                    nickName.text = PhotonNetwork.PlayerList[i].NickName;
                    continue;
                } else {
                    nickName = NickNameTexts[i + 1].GetComponent<Text>();
                    nickName.text = PhotonNetwork.PlayerList[i].NickName;
                    continue;
                }
                
            }
        }
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

    public void OnDie() {
        GameObject DeadPlayer = PhotonNetwork.Instantiate(DeadPlayerPrefab.name, PlayerGO.transform.position, PlayerGO.transform.rotation);
        PhotonNetwork.Destroy(PlayerGO);
    }
}
