using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHide : MonoBehaviour
{
    bool shown;
    public GameObject buttons;
    public GameObject buttonsPrefab;
    public GameObject Canvas;
    Vector3 buttonsPosition;
    private void Start()
    {
        buttonsPosition = buttons.transform.position;
        Destroy(buttons);
        shown = false;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && !shown)
        {
            buttons = Instantiate(buttonsPrefab, buttonsPosition, Quaternion.identity);
            buttons.transform.SetParent(Canvas.transform);
            shown = true;
        }
        if(Input.GetMouseButtonDown(1) && shown)
        {
            Destroy(buttons);
            shown = false;
        }
    }
}
