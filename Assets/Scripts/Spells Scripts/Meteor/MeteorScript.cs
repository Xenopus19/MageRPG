using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MeteorScript : Spell
{
    [Header("Meteor Parts")]
    [SerializeField] private GameObject Fireball;
    [SerializeField] private GameObject DestinationPoint;

    [Header("Custom Data")]
    [SerializeField] private float ExplosionRadius;
    [SerializeField] private float ExplosionDelay;
    [SerializeField] private float FireballFallingSpeed;

    [Header("Post Falling Effects")]
    [SerializeField] private GameObject Flame;
    [SerializeField] private GameObject Explosion;

    private void Start()
    {
        Fireball.transform.LookAt(DestinationPoint.transform);
        Fireball.GetComponent<Rigidbody>().AddForce(Fireball.transform.forward*FireballFallingSpeed, ForceMode.Impulse);
        StartCoroutine("Explode");
    }

    private IEnumerator Explode()
    {
        //Debug.Log("Meteor exploded");
        yield return new WaitForSeconds(ExplosionDelay);

        Destroy(Fireball);
        InstantiateEffects();
        DamagePlayers();
    }

    private void InstantiateEffects()
    {
        Instantiate(Explosion, DestinationPoint.transform.position, Quaternion.identity);
        GameObject flame =  Instantiate(Flame, DestinationPoint.transform.position, Quaternion.identity);
        flame.GetComponent<Spell>().Caster = Caster;
    }

    private void DamagePlayers()
    {
        Collider[] DamagedTargets = Physics.OverlapSphere(DestinationPoint.transform.position, ExplosionRadius);

        foreach(Collider targetCollider in DamagedTargets)
        {
            GameObject target = targetCollider.gameObject;
            if(PhotonNetwork.IsMasterClient)
            DamageTarget(target);
        }
    }
}
