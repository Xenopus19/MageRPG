using Photon.Pun;
using UnityEngine;

public class PlayerHP : Health {
    public float amountOfLifes = 3f;

    [SerializeField] private AudioSource audioSource;

    private LifeManager lifeManager;
    void Start() {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) 
        {
            ColorHp colorHP = GameObject.Find("PanelForHP").GetComponent<ColorHp>();
            colorHP.Init(gameObject);
            lifeManager = GameObject.Find("LifeManager")?.GetComponent<LifeManager>();
            lifeManager?.Init(gameObject);
        }
    }

    public void ResetHealth() {
        CurrentHealth = MaxHealth;
    }

    public override void Die() {
        if(photonView.IsMine)
        {
            amountOfLifes--;
            lifeManager.EndLife();
            if (amountOfLifes == 0)
            {
                lifeManager.EndGameForPlayer();
            }
        }
    }
}
