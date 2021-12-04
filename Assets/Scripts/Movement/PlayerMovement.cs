 using UnityEngine;
using Photon.Pun;

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

    private PhotonView photonView;

    private Animator anim;
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        anim = gameObject.GetComponent<Animator>();
    }

    private Animator GetAnimator() {
        if (anim == null) {
            anim = gameObject.GetComponent<Animator>();
        }
        if (anim == null) {
            Debug.LogError("Animator component not found");
            return null;
        } else {
            return anim;
        }
    }

    private void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    public void MovePlayer(float directionX, float directionZ) {
        Vector3 move = transform.right * directionX + transform.forward * directionZ;
        
        if (directionX == 0 && directionZ == 0) {
            GetAnimator().SetBool("Moving", false);
        } else
            GetAnimator().SetBool("Moving", true);
        controller.Move(move * speed * Time.deltaTime);
    }
    public void Jump()
    {
        if(isGrounded)
        velocity.y = Mathf.Sqrt(jumpHeigh * -2f * gravity);
    }
}
