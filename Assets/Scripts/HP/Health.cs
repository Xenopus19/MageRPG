using UnityEngine;
using System.Collections;
using System;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public float CurrentHealth { get; set; }

    public float MaxHealth;

    public PhotonView photonView;

    public event Action OnDamageReceived; 

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
        photonView?.RPC("RPC_DealDamageToObject", RpcTarget.All, IncomingDamage);
    }
    [PunRPC]
    public void RPC_DealDamageToObject(float IncomingDamage)
    {
        CurrentHealth -= IncomingDamage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
        if(OnDamageReceived!=null)
        OnDamageReceived();
    }

    public void ReceiveHealing(float IncomingHealing)
    {
        photonView.RPC("RPC_DealHealToObject", RpcTarget.All, IncomingHealing);
    }
    [PunRPC]
    public void RPC_DealHealToObject(float IncomingHealing)
    {
        CurrentHealth += IncomingHealing;


        if (CurrentHealth > MaxHealth)
            CurrentHealth = MaxHealth;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
