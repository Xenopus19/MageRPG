using UnityEngine;

public class ButtonsHide : MonoBehaviour {
    public GameObject buttons;
    public void Start() {
        buttons.SetActive(false);
    }
    public void CloseButtons() {
        buttons.SetActive(false);
    }
    public void ShowButtons() {
        buttons.SetActive(true);
    }
}
