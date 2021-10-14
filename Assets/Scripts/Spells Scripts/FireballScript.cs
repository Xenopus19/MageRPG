using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public GameObject Caster;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject != Caster)
        {
            collision.gameObject.GetComponent<HPPlayer>().hpPlayer -= 20;
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
