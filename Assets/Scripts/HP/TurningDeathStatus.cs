using UnityEngine;
using Photon.Pun;

public class TurningDeathStatus : MonoBehaviour {
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject gameUI;

    public void TurnOnDeathStatus(GameNetwork gameNetwork) {
        deathUI.SetActive(true);
        gameUI.SetActive(false);
        gameNetwork.OnDie();
    }
}
