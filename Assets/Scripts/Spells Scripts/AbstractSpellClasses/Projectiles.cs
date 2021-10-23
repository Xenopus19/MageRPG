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

        Rigidbody SpellPhysics = gameObject.GetComponent<Rigidbody>();
        SpellPhysics.AddForce(ray.direction * Force);
    }
}
