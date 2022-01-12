using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena4LavaScript : MonoBehaviour
{
    public int LavaDamage = 10;
    private void OnTriggerStay(Collider other)
    {
        float time = 0f;
        time += Time.deltaTime;
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
