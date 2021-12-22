using System;
using UnityEngine;

public class BarrageTile : Spell
{
    [SerializeField] GameObject DestroyParticle;
    [SerializeField] GameObject GODestroySFX;
    [SerializeField] AudioClip SFX;
    [SerializeField] LayerMask groundMask;
    private void Start()
    {
        Caster = GetComponentInParent<Spell>().Caster;
        IgnoreCollisionWithCaster();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isAlive) return;
        GameObject Target = collision.gameObject;
        if (Target.GetComponent<Spell>()?.Caster == Caster)
        {
            Physics.IgnoreCollision(Target.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            return;
        }
        else
        {
            DamageTarget(collision.transform.gameObject);
            CreateDestroyEffects();
            isAlive = false;
            Destroy(gameObject);
        }
    }

    private void CreateDestroyEffects()
    {
        Instantiate(DestroyParticle, gameObject.transform.position, Quaternion.identity);

        GameObject SFXObject = Instantiate(GODestroySFX, gameObject.transform.position, Quaternion.identity);
        SFXObject.GetComponent<AudioSource>().clip = SFX;
        SFXObject.SetActive(true);
    }
}
