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
    void Start()
    {
        InvokeRepeating("CreateFireball", TimeBetweenShots, 0);
    }

    private void CreateFireball()
    {
        print("Piu");
        Instantiate(Fireball, ShotSpawnPoint.transform.position, Quaternion.identity);
    }
}
