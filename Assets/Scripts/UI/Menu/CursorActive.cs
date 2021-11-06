using UnityEngine;

public class CursorActive : MonoBehaviour {
    void Start() {
        Cursor.visible = (true);
        Cursor.lockState = CursorLockMode.None;
    }
}
