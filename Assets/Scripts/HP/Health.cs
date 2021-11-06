using UnityEngine;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; private set; }

    [SerializeField] private float MaxHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void ReceiveDamage(float IncomingDamage)
    {
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
