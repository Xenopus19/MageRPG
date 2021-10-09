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
        Rigidbody FireBallPhysics = Fireball.GetComponent<Rigidbody>();
        FireBallPhysics.AddForce(gameObject.transform.GetChild(1).transform.forward * force);
    }
}
