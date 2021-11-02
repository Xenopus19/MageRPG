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
    private void Start()
    {
        StickCollider = gameObject.GetComponent<Collider>();
        StickAnimator = gameObject.GetComponent<Animator>();
        StickCollider.enabled = false;
    }

    void Update()
    {
        if (!GetComponentInParent<PhotonView>().IsMine) return;
        if (Input.GetKeyDown(AttackButton))
        {
            StickCollider.enabled = true;
            StickAnimator.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.GetComponent<Health>() != null)
        {
            target.GetComponent<Health>().ReceiveDamage(Damage);
        }
    }
}
