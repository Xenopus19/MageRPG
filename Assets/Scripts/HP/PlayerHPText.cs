using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(Health))]
public class PlayerHPText : MonoBehaviour
{
    private Health PlayerHealth;
    private Text HpText;
    private PhotonView photonView;
    public void ChangeHealthText()
    {
        if (!photonView.IsMine) return;
        float CurrentHealth = PlayerHealth.CurrentHealth;
        HpText.text = CurrentHealth.ToString();
    }
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        PlayerHealth = gameObject.GetComponent<Health>();
        HpText = GameObject.Find("HPText").GetComponent<Text>();
    }

    private void Update()
    {
        ChangeHealthText();
    }
}
