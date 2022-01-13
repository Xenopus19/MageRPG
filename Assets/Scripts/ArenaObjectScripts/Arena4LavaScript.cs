using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena4LavaScript : MonoBehaviour
{
    public int LavaDamage = 10;
    float time = 0f;

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject CollidedGO = other.gameObject;
        if (CollidedGO.GetComponent<Health>() != null)
        {
            if (time >= 0.6f)
            {
                CollidedGO.GetComponent<Health>().ReceiveDamage(LavaDamage);
                time = 0f;
            }
        }
    }
}
