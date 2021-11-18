using Photon.Pun;
using UnityEngine;

public class PlayerHP : Health {
    public float amountOfLifes = 3f;

    private RoundManager roundManager;

    private ColorHp colorHP;
    
    void Start() {
        Debug.Log("Player start executed");
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) {
            colorHP = GameObject.Find("PanelForHP").GetComponent<ColorHp>();
            colorHP.Init(gameObject);
            roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
            roundManager.Init(gameObject);
        }
    }

    public override void Die() {
        amountOfLifes--;
        if(photonView.IsMine)
        {
            roundManager.EndRound();
            if (amountOfLifes == 0)
            {
                roundManager.EndGameByLosing();
            }
        }
    }
}
