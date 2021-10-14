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
        InvokeRepeating("CreateFireball", TimeBetweenShots, 0);
    }

    private void CreateFireball()
    {
        GameObject FireBall = Instantiate(Fireball, ShotSpawnPoint.transform.position, Quaternion.identity);
        FireBall.GetComponent<FireballScript>().Caster = gameObject;
        Rigidbody FireBallPhysics = Fireball.GetComponent<Rigidbody>();
        FireBallPhysics.AddForce(gameObject.transform.forward * force);
    }
}
