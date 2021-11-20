using UnityEngine;
using UnityEngine.UI;

public class ColorHp : MonoBehaviour
{
    [SerializeField] Gradient healthGradient;
    [SerializeField] Image HealthBarImage;
    
    private float healthPercent;

    private float CurrentHealth;
    private float MaxHealth;

    private PlayerHP playerhp;
    public void Init (GameObject player)
    {
        playerhp = player.GetComponent<PlayerHP>();
    }
    void Update()
    {
        if(playerhp!=null)
        {
            CurrentHealth = playerhp.CurrentHealth;
            MaxHealth = playerhp.MaxHealth;
            healthPercent = CurrentHealth / MaxHealth;
            HealthBarImage.color = healthGradient.Evaluate(healthPercent);
        }
    }
}