using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(Health))]
public class PlayerHPText : MonoBehaviour
{
    private PlayerHP PlayerHealth;
    private Text HpText;
    private PhotonView photonView;
    private Text RoundsText;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (!photonView.IsMine) return;
        PlayerHealth = gameObject.GetComponent<PlayerHP>();
        HpText = GameObject.Find("HPText").GetComponent<Text>();
        RoundsText = GameObject.Find("RoundLeftText").GetComponent<Text>();
    }

    public void ChangeHealthText()
    {
        if (!photonView.IsMine) return;
        float CurrentHealth = PlayerHealth.CurrentHealth;
        HpText.text = CurrentHealth.ToString();
        RoundsText.text = "Lifes: " + PlayerHealth.amountOfLifes.ToString();
    }

    private void Update()
    {
        ChangeHealthText();
    }
}
