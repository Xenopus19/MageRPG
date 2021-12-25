using Photon.Pun;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FrozenOrbScript : Projectiles
{
    [SerializeField] float DamageMultiplier;
    [SerializeField] float SizeMultiplier;
    [SerializeField] float Lifetime;

    private PhotonView photonView;
    private float LivedTime;
    private void Update()
    {
        LivedTime += Time.deltaTime;

        gameObject.transform.localScale += Vector3.one * Time.deltaTime * SizeMultiplier;
        ActionAmount = Mathf.RoundToInt(ActionAmount + Time.deltaTime * DamageMultiplier);
    }

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        FlyForward();
        IgnoreCollisionWithCaster();
        StartCoroutine("DestroyWithEffect");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isAlive)
            return;

        GameObject Target = collision.gameObject;
        if (Target.GetComponent<Spell>()?.Caster == Caster)
        {
            Physics.IgnoreCollision(Target.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            return;
        }
        else
        {
            if(GetTargetHealth(Target)!=null)
            {
                if(PhotonNetwork.IsMasterClient)
                {
                    DamageTarget(Target);
                }
                CreateCollisionEffects();
                isAlive = false;
                Destroy(gameObject);
            }
            else
            {
                CreateCollisionEffects();
            }
        }
    }

    private IEnumerator DestroyWithEffect()
    {
        yield return new WaitForSeconds(Lifetime);
        CreateCollisionEffects();
        isAlive = false;
        Destroy(gameObject);
    }
}
