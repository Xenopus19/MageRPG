using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksOn : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            gameObject.SetActive(true);
        }
    }
}
