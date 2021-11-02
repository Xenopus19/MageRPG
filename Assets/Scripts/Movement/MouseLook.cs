using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float rotationX = 0f;

    private ButtonsHide buttonsHide;
    private bool buttonsShowing = false;
    private bool freezeCamera = false;
    private PhotonView photonView;
    void Start()
    {
        photonView = gameObject.GetComponentInParent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
        buttonsHide = GetComponent<ButtonsHide>();
    }
    void Update()
    {
        if (!photonView.IsMine)
            return; 

        if (!freezeCamera)
            MoveCamera();
        ChangeButtonsStatus();
    }
    private void ChangeButtonsStatus() {
        if (Input.GetMouseButtonDown(1)) {
            if (buttonsShowing) {
                Cursor.lockState = CursorLockMode.Locked;
                buttonsHide?.CloseButtons();
            } else {
                Cursor.lockState = CursorLockMode.None;
                buttonsHide?.ShowButtons();
            }
            buttonsShowing = !buttonsShowing;
            freezeCamera = !freezeCamera;
        }
    }
    private void MoveCamera() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
