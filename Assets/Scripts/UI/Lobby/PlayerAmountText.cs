using UnityEngine;
using UnityEngine.UI;

public class PlayerAmountText : MonoBehaviour {
    public void ChangePlayerAmountText(string text) {
        gameObject.GetComponent<Text>().text = $"Player: {text}";
    }
}
