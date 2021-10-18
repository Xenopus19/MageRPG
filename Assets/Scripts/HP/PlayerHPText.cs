using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class PlayerHPText : MonoBehaviour
{
    private Health PlayerHealth;
    private Text HpText;
    public void ChangeHealthText()
    {
        float CurrentHealth = PlayerHealth.CurrentHealth;
        HpText.text = CurrentHealth.ToString();
    }
    private void Start()
    {
        PlayerHealth = gameObject.GetComponent<Health>();
        HpText = GameObject.Find("HPText").GetComponent<Text>();
    }

    private void Update()
    {
        ChangeHealthText();
    }
}
