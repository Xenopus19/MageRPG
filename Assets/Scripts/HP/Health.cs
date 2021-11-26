using UnityEngine;
using System;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; set; }

    public float MaxHealth;

    public PhotonView photonView;

    public event Action<> OnDamageReceived; 

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    private void Start()
    {
        photonView = gameObject.GetComponent<PhotonView>();
    }
    public void ReceiveDamage(float IncomingDamage)
    {
        //if(PhotonNetwork.IsMasterClient&&photonView!=null)
        photonView.RPC("RPC_DealDamageToObject", RpcTarget.All, IncomingDamage);
    }
    [PunRPC]
    public void RPC_DealDamageToObject(float IncomingDamage)
    {
        CurrentHealth -= IncomingDamage;

        if (CurrentHealth <= 0)
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
