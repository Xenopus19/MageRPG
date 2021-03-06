using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float Damage;
    private Collider StickCollider;
    private Animator StickAnimator;
    public KeyCode AttackButton;
    public PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        StickCollider = gameObject.GetComponent<Collider>();
        StickAnimator = gameObject.GetComponent<Animator>();
        StickCollider.enabled = false;
        Collider UserCollider = gameObject.transform.parent.GetComponent<Collider>();
        Physics.IgnoreCollision(UserCollider, StickCollider);
    }

    public void Attack()
    {
        StickCollider.enabled = true;
        StickAnimator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            target.gameObject.GetComponent<Health>()?.ReceiveDamage(Damage);
        }
    }
    public void OnFinishAtack()
    {
        StickCollider.enabled = false;
    }
    
}
