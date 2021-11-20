using UnityEngine;
using UnityEngine.UI;

public class RoomText : MonoBehaviour
{
    public void ChangeRoomText(string text) {
        gameObject.GetComponent<Text>().text = $"Your room: {text}";
    }
}
