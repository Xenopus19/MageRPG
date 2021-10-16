using UnityEngine;

public class InputComponent : MonoBehaviour
{
    public KeyCode JumpCode = KeyCode.Space;

    private PlayerMovement _playerMovement;
    private ButtonsHide _buttonsHide;

    private bool _buttonsShowing = false;

    private void Start() {
        _playerMovement = GetComponent<PlayerMovement>();
        _buttonsHide = GetComponent<ButtonsHide>();
    }

    void Update() {
        if (Input.GetKeyDown(JumpCode)) {
            _playerMovement.TryJump();
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
