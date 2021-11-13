using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHp : MonoBehaviour
{
    [SerializeField] Gradient healthGradient;
    private PlayerHP playerhp;
    private float healthPercent;
    private float CurrentHealth;
    [SerializeField] Image HealthBarImage;
    private float MaxHealth;
    private GameObject Player;
    void Update()
    {
        CurrentHealth = playerhp.CurrentHealth;
        MaxHealth = playerhp.MaxHealth;
        healthPercent = CurrentHealth / MaxHealth;
        HealthBarImage.color = healthGradient.Evaluate(healthPercent);
    }
    public void Init (GameObject player)
    {
        Player = player;
        playerhp = Player.GetComponent<PlayerHP>();
    }
}