using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public bool isWalking;
    private bool isJumping;
    private float walkSpeed;
    private float runSpeed;
    private float jumpSpeed;

    private Camera cameraCharacter;
    private bool m_Jump;
    private float m_YRotation;
    private Vector2 input;
    private Vector3 m_MoveDir = Vector3.zero;
    private CharacterController characterController;
    private CollisionFlags m_CollisionFlags;
    private bool m_PreviouslyGrounded;
    private Vector3 originalCameraPosition;
    //private float stepCycle;
    //private float nextStep;
    private AudioSource audioSource;

    //private FOVKick fovKick = new FOVKick();
    //private bool useHeadBob;
    //private CurveControlledBob m_HeadBob = new CurveControlledBob();
    //private LerpControlledBob m_JumpBob = new LerpControlledBob();
    //private MouseLook m_MouseLook;
    //private float stepInterval;
    void Start() {
        characterController = GetComponent<CharacterController>();
        cameraCharacter = Camera.main;
        originalCameraPosition = cameraCharacter.transform.localPosition;
        //fovKick.Setup(camera);
        //m_HeadBob.Setup(cameraCharacter, stepInterval);
        //stepCycle = 0f;
        //nextStep = stepCycle / 2f;
        isJumping = false;
        audioSource = GetComponent<AudioSource>();
        //m_MouseLook.Init(transform, cameraCharacter.transform);
    }

    void Update() {

    }
    public void Walk(float horizontal, float vertical, bool wasWalking) {
        float speed = isWalking ? walkSpeed : runSpeed;
        input = new Vector2(horizontal, vertical);
        if (input.sqrMagnitude > 1)
            input.Normalize();
        //if (isWalking != wasWalking && m_UseFovKick && characterController.velocity.sqrMagnitude > 0) {
        //    StopAllCoroutines();
        //    StartCoroutine(!isWalking ? m_FovKick.FOVKickUp() : m_FovKick.FOVKickDown());
        //}
    }
    public void TryJump() {
        if (CanJump())
            Jump();
    }
    private bool CanJump() {
        return true;
    }

    private void Jump() {
        /*if (m_CharacterController.isGrounded)  <--- CanJump
        {
            m_MoveDir.y = -m_StickToGroundForce;

            if (m_Jump)                         <---- delete this if
            {
                m_MoveDir.y = m_JumpSpeed;
                PlayJumpSound();
                m_Jump = false;                 <---- delete this if
                m_Jumping = true;
            }
        }*/
    }
}
