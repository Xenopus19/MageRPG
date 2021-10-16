using UnityEngine;

public class InputComponent : MonoBehaviour
{
    public KeyCode JumpCode = KeyCode.Space;

    private PlayerMovement playerMovement;
    private ButtonsHide buttonsHide;

    private bool _buttonsShowing = false;

    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        buttonsHide = GetComponent<ButtonsHide>();
    }

    void Update() {
        if (Input.GetKeyDown(JumpCode)) {
            playerMovement.TryJump();
        }

        if (Input.GetMouseButton(1)) {
            //if (_buttonsShowing)
            //    _buttonsHide.CloseButtons();
            //else
            //    _buttonsHide.ShowButtons();
            _buttonsShowing = !_buttonsShowing;
        }
    }
}
