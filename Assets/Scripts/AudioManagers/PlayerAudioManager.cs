using Photon.Pun;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] FootstepSounds;

    private AudioSource audioSource;
    private float StepChangeTime = 2;
    private float StepChangeCooldown = 0;
    private PlayerMovement playerMovement;
    private PhotonView photonView;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        photonView = GetComponent<PhotonView>();
        audioSource.mute = true;
    }

    private void Update() 
    { 
        //PlayFootsteps();
        //SetRandomFootstepSFX();
        if (photonView != null && playerMovement.isActiveAndEnabled) {
            if (photonView.IsMine) {
                //photonView.RPC("PlayFootsteps", RpcTarget.All);
                PlayFootsteps();
                SetRandomFootstepSFX();
            }
        }
    }
    //[PunRPC]
    public void PlayFootsteps()
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
