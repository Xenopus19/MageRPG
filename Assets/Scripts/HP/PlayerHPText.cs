using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPText : MonoBehaviour
{
public static void ChangeHealthText(float hpPlayer)
    {
        GameObject.Find("HPText").GetComponent<Text>().text = $"{hpPlayer}";
    }
}
