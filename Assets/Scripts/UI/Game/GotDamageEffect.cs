using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Health))]
public class GotDamageEffect : MonoBehaviour
{
    public Health health;
    public AudioSource audioSourse;

    [SerializeField] private AudioClip[] DamageSoundVariations;
    [SerializeField] private GameObject ParticleEffect;

    void Start()
    {
        health.OnDamageReceived += FrontendEffects;
        
    }

    public virtual void FrontendEffects()
    {
        CreateParticleEffect();
        PlaySound();
    }

    public void CreateParticleEffect()
    {
        Instantiate(ParticleEffect, gameObject.transform.position, Quaternion.identity);
    }
    public void PlaySound()
    {
        audioSourse.clip = DamageSoundVariations[Random.Range(0, DamageSoundVariations.Length-1)];
        audioSourse.Play();
    }
}
