using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Spell))]
public class FireballScript : Projectiles
{

    private void Start()
    {
        Physics.IgnoreCollision(Caster.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        for(int i = 0; i < Caster.transform.childCount; i++)
        {
            if(Caster.transform.GetChild(i).GetComponent<Collider>()!=null)
            Physics.IgnoreCollision(Caster.transform.GetChild(i).GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }

        FlyForward();
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject Target = collision.gameObject;

        if (Target.GetComponent<Health>()!=null )
        {
            Target.GetComponent<Health>().ReceiveDamage(ActionAmount);
            Destroy(gameObject);
        }
        else if(Target.GetComponentInChildren<Health>() != null)
        {
            Target.GetComponentInChildren<Health>().ReceiveDamage(ActionAmount);
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
