using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManaItem : MonoBehaviour
{
    [SerializeField] private float ManaToRefill;
    [SerializeField] private float Lifetime;
    [SerializeField] private AudioSource audioSource;

    private float LivedTime;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        collider.gameObject.GetComponent<ManaPlayer>()?.RefillMana(ManaToRefill);
        Destroy(gameObject);
    }

    private void Update()
    {
        LivedTime += Time.deltaTime;
        if (LivedTime >= Lifetime)
            Destroy(gameObject);
    }
}
