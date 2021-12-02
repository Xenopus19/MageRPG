using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballScript : Projectiles
{
    private PhotonView photonView;

    private void Start()
    {   
        photonView = GetComponent<PhotonView>();
        GetAnimator();
        anim.Play("FireBallAndFrostboltCastAnim");
        FlyForward();
        IgnoreCollisionWithCaster();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;
        //Debug.LogWarning(Target.name);
        if (PhotonNetwork.IsMasterClient)
        {
            DamageTarget(Target);
        }
        Destroy(gameObject);
    }
}
