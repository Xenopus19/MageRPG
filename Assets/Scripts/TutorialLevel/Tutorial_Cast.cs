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

        if(Input.GetMouseButtonDown(0))
        {
            if(!CodeEraseInstructionShown)
            {
                FireballCastInstruction.SetActive(false);
                EraseCodeAndSpellbookText.SetActive(true);
                CodeEraseInstructionShown = true;
            }
        }
    }

    public void MoveToNextScreen()
    {
        ThirdScreen.SetActive(true);
        EraseCodeAndSpellbookText.SetActive(false);
    }
}
