using UnityEngine;

public class InputComponent : MonoBehaviour {
    public KeyCode jumpCode = KeyCode.Space;
    private bool buttonsShowing = false;

    private PlayerMovement playerMovement;
    private ButtonsHide buttonsHide;
    


    private void Start() {
        playerMovement = GetComponent<PlayerMovement>();
        buttonsHide = GetComponent<ButtonsHide>();
    }

    void Update() {
        InputWalking();
        InputJump();

        ButtonsStatusChange();
    }
    private void InputWalking() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool wasWalking = playerMovement.isWalking;
        playerMovement.isWalking = !Input.GetKey(KeyCode.LeftShift);

        playerMovement.Walk(horizontal, vertical, wasWalking);
        
    }

    private void InputJump() {
        if (Input.GetKeyDown(jumpCode)) {
            playerMovement.TryJump();
        }
    }

    private void ButtonsStatusChange() {
        if (Input.GetMouseButton(1)) {
            if (buttonsShowing)
                buttonsHide.CloseButtons();
            else
                buttonsHide.ShowButtons();
            buttonsShowing = !buttonsShowing;
        }
    }
}
