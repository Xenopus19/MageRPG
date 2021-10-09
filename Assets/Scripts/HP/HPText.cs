using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    public static void ChangeHealthText(float hpPlayer) {
        GameObject.Find("HPText").GetComponent<Text>().text = $"{hpPlayer}";
    }
}
