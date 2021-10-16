using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHP : MonoBehaviour
{
    public float DummyHPs = 100;
    private void Update()
    {
        if(DummyHPs <= 0)
        {
            Destroy(gameObject);
        }
    }
}
