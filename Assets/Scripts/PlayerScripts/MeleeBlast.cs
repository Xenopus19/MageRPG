using Photon.Pun;
using UnityEngine;

public class MeleeBlast : MonoBehaviour
{
    [SerializeField] private float AttackRadius;
    [SerializeField] private float MaxDamage;
    [SerializeField] private float MinDamage;
    [SerializeField] private float Cooldown;

    [SerializeField] private GameObject Particle;

    [SerializeField] private Transform DamageCircleCenter;

    private float TimeSinceLastBlast;

    private void Update()
    {
        TimeSinceLastBlast += Time.deltaTime;
    }

    public void DoAttack()
    {
        if (TimeSinceLastBlast < Cooldown) return;

        CreateParticle();

        int damage = (int)Random.Range(MinDamage, MaxDamage);
        Collider[] DamagedColliders = Physics.OverlapSphere(DamageCircleCenter.position, AttackRadius);

        foreach(Collider collider in DamagedColliders)
        {
            GameObject target = collider.gameObject;
            if(target != gameObject)
            {
                target.GetComponent<Health>()?.ReceiveDamage(damage);
            }
        }
        TimeSinceLastBlast = 0;
    }

    private void CreateParticle()
    {
        PhotonNetwork.Instantiate(Particle.name, DamageCircleCenter.position, Quaternion.identity);
    }

}
