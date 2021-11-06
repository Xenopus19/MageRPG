using Photon.Pun;
using UnityEngine;

public class PlayerHP : Health {
    private float amountOfLifes = 3f;

    private GameNetwork gameNetwork;

    void Start() {
        gameNetwork = GameObject.Find("GameNetworkManager").GetComponent<GameNetwork>();
    }

    public override void Die() {
        amountOfLifes--;
        if (amountOfLifes == 0) {
            gameNetwork.LeaveRoom();
        }
    }
}
