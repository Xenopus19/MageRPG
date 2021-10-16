using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

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
