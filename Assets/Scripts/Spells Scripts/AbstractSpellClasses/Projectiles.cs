using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : Spell
{
    [Header("On Collision Effects")]
    [SerializeField] private AudioClip OnCollisionSound;
    [SerializeField] public GameObject OnCollisionParticle;


    [SerializeField] float Force;
    public void FlyForward()
    {
        Ray ray = new Ray();
        if(Caster.GetComponentInChildren<MouseLook>() != null)
        {
            GameObject CasterCamera = Caster.GetComponentInChildren<MouseLook>().gameObject;
            ray.origin = CasterCamera.transform.position;
            ray.direction = CasterCamera.transform.forward;
        }
        else
        {
            ray.origin = Caster.transform.position;
            ray.direction = Caster.transform.forward;
        }

        //GetComponent<AudioSource>()?.Play();
        Rigidbody SpellPhysics = gameObject.GetComponent<Rigidbody>();
        SpellPhysics.AddForce(ray.direction * Force);
    }

    public void CreateCollisionEffects()
    {
        MakeExplosion();
        PlayExplosionSound();
    }

    private void MakeExplosion()
    {
        if (OnCollisionParticle != null)
        {
            GameObject effect = Instantiate(OnCollisionParticle, gameObject.transform.position, Quaternion.identity);
            effect.SetActive(true);
        }
    }

    private void PlayExplosionSound()
    {
        AudioSource audio = GetComponent<AudioSource>();
        Debug.LogError("Sound played");
        if(audio!=null)
        {
            audio.clip = OnCollisionSound;
            audio.Play();
        }
    }
}
