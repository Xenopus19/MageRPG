using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSpeed : MonoBehaviour
{
    public float DebuffTime;
    public float SpeedToDecrease;

    private float LivedTime;
    private float OriginalSpeed;
    private PlayerMovement movement;

    private void Start()
    {
        movement = gameObject.GetComponent<PlayerMovement>();
        OriginalSpeed = movement.speed;
        movement.speed -= SpeedToDecrease;
    }

    private void Update()
    {
        LivedTime += Time.deltaTime;
        if (LivedTime >= DebuffTime)
        {
            movement.speed = OriginalSpeed;
            Destroy(this);
        }            
    }
}
