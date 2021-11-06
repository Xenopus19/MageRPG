using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class ColorHp : MonoBehaviour
{
    [SerializeField] Gradient healthGradient;
    private Health PlayerHealth;
    private float healthPercent;
    [SerializeField] Image HealthBarImage;
    [SerializeField] float MaxHealth;

    void Start()
    {
        PlayerHealth = gameObject.GetComponent<Health>();
    }
    void Update()
    {
        float CurrentHealth = PlayerHealth.CurrentHealth;
        healthPercent = CurrentHealth / MaxHealth;
        HealthBarImage.color = healthGradient.Evaluate(healthPercent);
    }
}