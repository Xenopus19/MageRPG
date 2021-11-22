using Photon.Pun;
using UnityEngine;

public class PlayerHP : Health {
    public float amountOfLifes = 3f;

    private LifeManager lifeManager;

    private ColorHp colorHP;
    
    void Start() {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) {
            colorHP = GameObject.Find("PanelForHP").GetComponent<ColorHp>();
            colorHP.Init(gameObject);
            lifeManager = GameObject.Find("RoundManager").GetComponent<LifeManager>();
            lifeManager.Init(gameObject);
        }
    }

    public override void Die() {
        amountOfLifes--;
        if(photonView.IsMine)
        {
            lifeManager.EndLife();
            if (amountOfLifes == 0)
            {
                lifeManager.EndGameByLosing();
            }
        }
    }
}
