using Photon.Pun;
using UnityEngine;

public class PlayerHP : Health {
    private float amountOfLifes = 3f;

    private PhotonView photonView;

    private RoundManager roundManager;

    void Start() {
        photonView = gameObject.GetComponent<PhotonView>();
        if (photonView.IsMine) {
            roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
            roundManager.Init(gameObject);
        }
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ReceiveDamage(MaxHealth);
        }
    }

    public override void Die() {
        amountOfLifes--;
        roundManager.EndRound();
        if (amountOfLifes == 0) {
            roundManager.EndGameByLosing();
        }
    }
}
