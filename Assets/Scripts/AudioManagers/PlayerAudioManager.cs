using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] FootstepSounds;

    private AudioSource audioSource;
    private float StepChangeTime = 2;
    private float StepChangeCooldown = 0;
    private PlayerMovement playerMovement;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        PlayFootsteps();
        SetRandomFootstepSFX();
    }

    private void PlayFootsteps()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && playerMovement.isGrounded)
        {
            audioSource.mute = false;
        }
        else 
        {
            audioSource.mute = true;
        }
    }

    private void SetRandomFootstepSFX()
    {
        StepChangeCooldown += Time.deltaTime;

        if(StepChangeCooldown>=StepChangeTime)
        {
            audioSource.clip = FootstepSounds[Random.Range(0, FootstepSounds.Length - 1)];
            audioSource.Play();
            StepChangeCooldown = 0;
        }
    }
}
