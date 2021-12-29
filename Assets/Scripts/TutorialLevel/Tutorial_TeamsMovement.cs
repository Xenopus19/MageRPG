using System;
using UnityEngine;

public class Tutorial_TeamsMovement : MonoBehaviour
{
    [SerializeField] private GameObject ToggleTeamsText;
    [SerializeField] private GameObject WalkText;

    [SerializeField] private GameObject SecondScreen;

    private int WalkingKeysPressed = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleTeamsText.SetActive(false);
        }

        if(AnyMovementKeyPressed())
        {
            WalkingKeysPressed++;
            if(WalkingKeysPressed >= 4)
            {
                WalkText.SetActive(false);
            }
        }

        if(ToggleTeamsText.activeInHierarchy == false && WalkText.activeInHierarchy == false)
        {
            SecondScreen.SetActive(true);
        }
    }

    private bool AnyMovementKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D);
    }
}
