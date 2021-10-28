using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaItem : MonoBehaviour
{
    [SerializeField] private float ManaToRefill;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<ManaPlayer>()?.RefillMana(ManaToRefill);
    }
}
