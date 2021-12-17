using UnityEngine;
using Photon.Pun;

public class TurningDeathStatus : MonoBehaviour {
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject gameUI;
    private GameObject player;

    public void TurnOnDeathStatus(GameObject Player, PhotonView photonView) {
        deathUI.SetActive(true);
        gameUI.SetActive(false);
        Player.GetComponent<PlayerHP>().enabled = false;
        Player.GetComponent<PlayerHP>().enabled = false;
        Player.GetComponent<GotDamageEffect>().enabled = false;
        Player.GetComponent<PlayerHPText>().enabled = false;
        Player.GetComponent<ManaPlayer>().enabled = false;
        Player.GetComponent<ManaText>().enabled = false;
        Player.GetComponent<SpellCast>().enabled = false;
        Player.GetComponent<SpellIconsChange>().enabled = false;
        Player.GetComponent<BasicShot>().enabled = false;
        Player.GetComponent<AboveObjectHPBar>().enabled = false;
        player = Player;
        photonView.RPC("RemoveMesh", RpcTarget.All);
        RemoveMesh();
    }
    [PunRPC]
    public void RemoveMesh() {
        for (int i = 0; i < player.transform.childCount; i++) {
            GameObject child = player.transform.GetChild(i).gameObject;
            SkinnedMeshRenderer skinnedMeshRenderer = child?.GetComponent<SkinnedMeshRenderer>();
            if (skinnedMeshRenderer != null) {
                skinnedMeshRenderer.enabled = false;
            }
        }
    }
}
