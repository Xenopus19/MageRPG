using Photon.Pun;
using UnityEngine;

public class PlayerHP : Health {
    public float amountOfLifes = 3f;

    [SerializeField] private AudioSource audioSource;

    private LifeManager lifeManager;
    private PlayerInputController inputController;

    private ColorHp colorHP;
    
    void Start() {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine) {
            colorHP = GameObject.Find("PanelForHP").GetComponent<ColorHp>();
            colorHP.Init(gameObject);
            lifeManager = GameObject.Find("LifeManager").GetComponent<LifeManager>();
            lifeManager.Init(gameObject);
            inputController = GetComponent<PlayerInputController>();
        }
    }

    public override void Die() {
        if(photonView.IsMine)
        {
            amountOfLifes--;
            lifeManager.EndLife();
            if (amountOfLifes == 0)
            {
                inputController.IsFreeze = true;
                lifeManager.EndGameForPlayer();
            }
        }
    }
}
