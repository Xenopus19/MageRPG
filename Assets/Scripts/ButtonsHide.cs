using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHide : MonoBehaviour
{
    bool shown = false;
    public GameObject buttons;
    public void Start()
    {
        buttons.SetActive(false);
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(1) && shown == false)
        {
            buttons.SetActive(true);
            shown = true;
        }
        else if(Input.GetMouseButtonDown(1) && shown == true)
        {
            buttons.SetActive(false);
            shown = false;
        }
    }
}
