using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroyOnTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
