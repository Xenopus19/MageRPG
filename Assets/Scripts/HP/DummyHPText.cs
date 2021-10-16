using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyHPText : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<TextMesh>().text = "" + gameObject.GetComponent<DummyHP>().DummyHPs;
    }
}
