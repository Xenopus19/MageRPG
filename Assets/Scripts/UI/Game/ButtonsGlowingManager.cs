using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsGlowingManager : MonoBehaviour
{
    public bool WasEraseKeyPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            WasEraseKeyPressed = true;
    }
}
