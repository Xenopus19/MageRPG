using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; set; }

    public float MaxHealth;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    [PunRPC] 
    
    public void ReceiveDamage(float IncomingDamage)
    {
        Debug.Log("ahahahahahahahaha");
        CurrentHealth -= IncomingDamage;

        if(CurrentHealth<=0)
        {
            Die();
        }
    }

    public void ReceiveHealing(float IncomeingHealing)
    {
        CurrentHealth += IncomeingHealing;


        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
