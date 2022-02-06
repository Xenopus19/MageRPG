using Photon.Pun;
using UnityEngine;

public class PlayerFinalDeathEffect : MonoBehaviour
{
    [SerializeField] GameObject DeathEffect;

    private void Start()
    {
        PhotonNetwork.Instantiate(DeathEffect.name, transform.position, Quaternion.identity);
    }
}
