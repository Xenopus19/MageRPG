using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastFireball : MonoBehaviour
{
    [SerializeField]
    private GameObject Fireball;
    [SerializeField]
    private GameObject ShotSpawnPoint;

    [SerializeField]
    private float TimeBetweenShots;
    public float force;
    void Start()
    {
        InvokeRepeating("CreateFireball", 1, TimeBetweenShots);
    }

    private void CreateFireball()
    {
        GameObject NewFireball = Instantiate(Fireball, ShotSpawnPoint.transform.position, Quaternion.identity);
        NewFireball.GetComponent<FireballScript>().Caster = gameObject;

        Ray ray = new Ray();
        ray.origin = ShotSpawnPoint.transform.position;
        ray.direction = gameObject.transform.forward;

        Rigidbody FireBallPhysics = NewFireball.GetComponent<Rigidbody>();
        FireBallPhysics.AddForce(ray.direction * force);
    }
}
