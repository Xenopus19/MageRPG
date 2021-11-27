using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] private float Lifetime;

    private float LivedTime;

    private void CheckTime()
    {
        LivedTime += Time.deltaTime;
        if (LivedTime >= Lifetime)
            Destroy(gameObject);
    }

    private void Update()
    {
        CheckTime();
    }
}
