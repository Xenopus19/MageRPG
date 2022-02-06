using Photon.Pun;
using UnityEngine;

public class PlayerFinalDeathEffect : MonoBehaviour
{
    [SerializeField] GameObject DeathEffect;

    private PhotonView photonView;
    public void CreateEffects()
    {
        PhotonNetwork.Instantiate(DeathEffect.name, transform.position, Quaternion.identity);
    }
}
