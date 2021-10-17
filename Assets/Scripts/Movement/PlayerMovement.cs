using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeigh = 3f;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public KeyCode jumpCode = KeyCode.Space;
    
    Vector3 velocity;
    public bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * directionX + transform.forward * directionZ;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(jumpCode) && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
