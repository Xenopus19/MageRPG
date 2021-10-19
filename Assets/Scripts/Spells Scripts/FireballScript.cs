using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Spell))]
public class FireballScript : Spell
{
    public GameObject Caster;

    private void Start()
    {
        Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        for(int i = 0; i < Caster.transform.childCount; i++)
        {
            Physics.IgnoreCollision(Caster.transform.GetChild(i).GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;

        if (Target.GetComponent<Health>()!=null)
        {
            Target.GetComponent<Health>().ReceiveDamage(Damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        /*if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPPlayer>().GetDamage(20f);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Dummy" && Caster.tag != "Dummy")
        {
            collision.gameObject.GetComponent<DummyHP>().DummyHPs -= 20f;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }
}
