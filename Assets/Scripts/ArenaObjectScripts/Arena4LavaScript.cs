using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena4LavaScript : MonoBehaviour
{
    public int LavaDamage = 10;
    private void OnCollisionStay(Collision collision)
    {
        float time = 0.2f;
        time += Time.deltaTime;
        GameObject CollidedGO = collision.gameObject;
        if(CollidedGO.GetComponent<Health>() != null)
        {
            if(time >= 0.2f)
            {
                CollidedGO.GetComponent<Health>().ReceiveDamage(LavaDamage);
            }
        }
    }
}
