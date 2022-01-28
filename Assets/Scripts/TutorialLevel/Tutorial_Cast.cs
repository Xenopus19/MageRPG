using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Cast : MonoBehaviour
{
    [SerializeField] private GameObject OpenCastConsoleText;
    [SerializeField] private GameObject FireballCastInstruction;
    [SerializeField] private GameObject EraseCodeAndSpellbookText;

    [SerializeField] private GameObject ThirdScreen;

    private bool CastInstructionsShown = false;
    private bool CodeEraseInstructionShown = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!CastInstructionsShown)
            {
                OpenCastConsoleText.SetActive(false);
                FireballCastInstruction.SetActive(true);
                CastInstructionsShown = true;
            }
            
        }

        if(Input.GetMouseButtonDown(0) && OpenCastConsoleText.activeInHierarchy == false)
        {
            if(!CodeEraseInstructionShown)
            {
                FireballCastInstruction.SetActive(false);
                EraseCodeAndSpellbookText.SetActive(true);
                CodeEraseInstructionShown = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.H) && EraseCodeAndSpellbookText.activeInHierarchy)
        {
            MoveToNextScreen();
        }
    }

    public void MoveToNextScreen()
    {
        ThirdScreen.SetActive(true);
        EraseCodeAndSpellbookText.SetActive(false);
    }
}
