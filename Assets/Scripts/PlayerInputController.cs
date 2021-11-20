using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] GameObject Stick;

    [Space(20f)]

    [SerializeField] private KeyCode MeleeAttackButton;
    [SerializeField] private KeyCode SpellCastButton;
    [SerializeField] private KeyCode JumpKey;

    private PlayerMovement playerMovement;
    private MeleeAttack melee;
    private PhotonView photonView;
    private SpellCast spellCast;

    private void Start()
    {
        spellCast = GetComponent<SpellCast>();
        melee = Stick.GetComponent<MeleeAttack>();
        photonView = GetComponent<PhotonView>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!photonView.IsMine) return;

        GetAndExecuteMovementInput();
        GetMeleeInput();
        GetSpellCastInput();
    }

    private void GetAndExecuteMovementInput()
    {
        if(Input.GetKeyDown(JumpKey))
        {
            playerMovement.Jump();
        }

        float directionX = Input.GetAxis("Horizontal");
        float directionZ = Input.GetAxis("Vertical");
        playerMovement.MovePlayer(directionX, directionZ);
    }

    private void GetMeleeInput()
    {
        if(Input.GetKeyDown(MeleeAttackButton))
        {
            melee.Attack();
        }
    }

    private void GetSpellCastInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            spellCast.StartCasting();
        }
    }
}
