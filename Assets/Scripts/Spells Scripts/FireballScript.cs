using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class FireballScript : Projectiles
{
    [SerializeField] private GameObject ExplosionParticle;

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
        if (Target.GetComponent<Spell>()?.Caster == Caster)
        {
            Physics.IgnoreCollision(Target.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            return;
        }
        else
        {
            if (PhotonNetwork.IsMasterClient)
            {
                DamageTarget(Target);
            }
            CreateExplosion();
            Destroy(gameObject);
        }
        
        //Debug.LogWarning(Target.name);
    }

    private void CreateExplosion()
    {
        if(ExplosionParticle!=null)
        {
            GameObject effect = Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);
            effect.SetActive(true);
        }
    }
}
