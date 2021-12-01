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
        //IgnoreCollisionWithCaster();
    }
    private void OnCollisionEnter(Collision collision)
    {
        DamageTarget(collision.transform.gameObject);
        CreateDestroyEffects();
        Destroy(gameObject);
    }

    private void CreateDestroyEffects()
    {
        Instantiate(DestroyParticle, gameObject.transform.position, Quaternion.identity);

        GameObject SFXObject = Instantiate(GODestroySFX, gameObject.transform.position, Quaternion.identity);
        SFXObject.GetComponent<AudioSource>().clip = SFX;
        SFXObject.SetActive(true);
    }
}
