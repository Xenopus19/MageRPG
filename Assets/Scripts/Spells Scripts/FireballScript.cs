using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public GameObject Caster;
    private void Start()
    {
        Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPPlayer>().hpPlayer -= 20f;
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Dummy")
        {
            collision.gameObject.GetComponent<DummyHP>().DummyHPs -= 20f;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
