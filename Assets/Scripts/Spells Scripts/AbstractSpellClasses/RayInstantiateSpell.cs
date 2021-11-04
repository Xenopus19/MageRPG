using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInstantiateSpell : Spell
{
    [SerializeField] private GameObject StructureToInstantiate;
    [SerializeField] private float MaxInstantiateDistance;

    public void SpawnStructure(Ray ray)
    {
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.layer == 10)
            {
                GameObject NewStructure = Instantiate(StructureToInstantiate, hit.point, Caster.transform.rotation);
            }
        }
    }
    public Ray CreateRay()
    {
        Ray ray = new Ray();
        if (Caster.GetComponentInChildren<MouseLook>() != null)
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

        ray.direction *= MaxInstantiateDistance;

        return ray;
    }
}
