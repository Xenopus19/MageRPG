using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Mana : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private GameObject ManaExplanation;
    [SerializeField] private GameObject BasicAttacksExplanation;
    [SerializeField] private GameObject FourthScreen;

    [Header("Mana Item")]
    [SerializeField] private GameObject ManaItem;
    [SerializeField] private Transform ItemPosition;

    private GameObject ManaItemObject;

    private bool FPressed;
    private bool RPressed;

    private void Start()
    {
        ExplainMana();
    }

    private void Update()
    {
        if(ManaItemObject==null)
        {
            ManaExplanation.SetActive(false);
            BasicAttacksExplanation.SetActive(true);
        }

        WasBasicShotKeyPressed();

        if(FPressed && RPressed)
        {
            FourthScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void ExplainMana()
    {
        GameObject Player = GameObject.Find("Mage");
        Player.GetComponent<ManaPlayer>().DecrementMana(50f);

        ManaItemObject =  Instantiate(ManaItem, ItemPosition.position, Quaternion.identity);
    }

    private void WasBasicShotKeyPressed()
    {
        if (BasicAttacksExplanation.activeInHierarchy && Input.GetKeyDown(KeyCode.F))
        {
            FPressed = true;
        }

        if(BasicAttacksExplanation.activeInHierarchy && Input.GetKeyDown(KeyCode.R))
        {
            RPressed = true;
        }
    }
}
