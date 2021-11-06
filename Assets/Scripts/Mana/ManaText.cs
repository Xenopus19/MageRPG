using UnityEngine.UI;
using UnityEngine;

public class ManaText : MonoBehaviour
{
    public static void ChangeManaText(float manaPlayer) 
    {
        GameObject.Find("ManaText").GetComponent<Text>().text = $"{manaPlayer}";
    }
    
}
