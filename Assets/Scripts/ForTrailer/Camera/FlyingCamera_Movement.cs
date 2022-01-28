using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCamera_Movement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] float speedChange;
    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * Speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * Speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * Speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * Speed;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * Time.deltaTime * Speed;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            Speed += speedChange * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Speed += speedChange * Time.deltaTime;
        }
    }
}
