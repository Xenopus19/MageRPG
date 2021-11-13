using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : Spell
{
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

    public void IgnoreCollisionWithCaster()
    {
        if(Caster.GetComponent<Collider>()!=null)
        {
            Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
        
        for (int i = 0; i < Caster.transform.childCount; i++)
        {
            Collider CasterChildCollider = Caster.transform.GetChild(i).GetComponent<Collider>();
            if (CasterChildCollider != null)
            {
                Physics.IgnoreCollision(CasterChildCollider, gameObject.GetComponent<Collider>());
                //Debug.LogError(CasterChildCollider.gameObject.name);
            }

        }

        gameObject.GetComponent<Collider>().enabled = true;
    }
}
