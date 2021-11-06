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
    public void ChangeHealthText()
    {
        if (!photonView.IsMine) return;
        float CurrentHealth = PlayerHealth.CurrentHealth;
        HpText.text = CurrentHealth.ToString();
        RoundsText.text = PlayerHealth.amountOfLifes.ToString();
    }
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        PlayerHealth = gameObject.GetComponent<PlayerHP>();
        HpText = GameObject.Find("HPText").GetComponent<Text>();
        RoundsText = GameObject.Find("RoundLeftText").GetComponent<Text>();
    }

    private void Update()
    {
        ChangeHealthText();
    }
}
