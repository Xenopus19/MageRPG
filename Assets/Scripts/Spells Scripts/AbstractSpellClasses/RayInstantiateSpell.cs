using Photon.Pun;
using UnityEngine;

public class RayInstantiateSpell : Spell
{
    [SerializeField] public GameObject StructureToInstantiate;
    [SerializeField] private float MaxInstantiateDistance;
    public GameObject SpawnStructure(Ray ray, bool IsNetworkInstantiate)
    {
        /*if(Physics.Raycast(ray, out RaycastHit hit))
        {
            //if (true)/*hit.collider.gameObject.layer == 10
            {
                if (IsNetworkInstantiate)
                {
                    GameObject NewStructure = PhotonNetwork.Instantiate(StructureToInstantiate.name, hit.point, Caster.transform.rotation);
                }
                else
                {
                    GameObject NewStructure = Instantiate(StructureToInstantiate, hit.point, Caster.transform.rotation);
                    SetupStructure(NewStructure);
                    return NewStructure;
                }
            }
        }*/
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject.layer != 3 && hit.collider.gameObject.layer != 13)
            {
                if (IsNetworkInstantiate)
                {
                    GameObject NewStructure = PhotonNetwork.Instantiate(StructureToInstantiate.name, hit.point, Caster.transform.rotation);
                }
                else
                {
                    GameObject NewStructure = Instantiate(StructureToInstantiate, hit.point, Caster.transform.rotation);
                    SetupStructure(NewStructure);
                    return NewStructure;
                }
                break; 
            }
        }
        return null;
    }

    private void SetupStructure(GameObject structure)
    {
        Spell structureData = structure.GetComponent<Spell>();
        if(structureData != null)
        {
            structureData.Caster = Caster;
            structureData.ActionAmount += ActionAmount;
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
