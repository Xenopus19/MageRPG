using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookScript : MonoBehaviour
{
    public SpellBookPageDataScript[] SpellDatas;
    [SerializeField] private GameObject Page1;
    [SerializeField] private GameObject Page2;
    private SpellBookPageScript SpellBookPage1Script;
    private SpellBookPageScript SpellBookPage2Script;
    private int PageNumber;

    private void Start()
    {
        SpellBookPage1Script = Page1.GetComponent<SpellBookPageScript>();
        SpellBookPage2Script = Page2.GetComponent<SpellBookPageScript>();
        PageNumber = 0;
        UpdateData(PageNumber, PageNumber + 1);
    }

    public void NextPage()
    {
        if (PageNumber == SpellDatas.Length - 1) PageNumber = 0;
        else PageNumber += 1;

        if(PageNumber == SpellDatas.Length - 1) UpdateData(PageNumber, 0);
        else UpdateData(PageNumber, PageNumber + 1);
    }

    public void PreviousPage()
    {
        if (PageNumber == 0) PageNumber = SpellDatas.Length - 1;
        else PageNumber -= 1;

        if (PageNumber == SpellDatas.Length - 1) UpdateData(PageNumber, 0);
        else UpdateData(PageNumber, PageNumber + 1);
    }

    private void UpdateData(int number1, int number2)
    {
        SpellBookPage1Script.ChangeData(SpellDatas[number1]);
        SpellBookPage2Script.ChangeData(SpellDatas[number2]);
    }
}
