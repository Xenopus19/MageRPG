using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ManaItem : MonoBehaviour
{
    [SerializeField] private float ManaToRefill;
    [SerializeField] private AudioClip SFXAudio;
    [SerializeField] private GameObject EffectGO;
    [SerializeField] private GameObject Perticle;



    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        collider.gameObject.GetComponent<ManaPlayer>()?.RefillMana(ManaToRefill);
        CreatePickedEffects();
        Destroy(gameObject);
        
    }

    private void CreatePickedEffects()
    {
        GameObject SFX = Instantiate(EffectGO, gameObject.transform.position, Quaternion.identity);
        GameObject ParticleEffect = Instantiate(Perticle, gameObject.transform.position, Quaternion.identity);

        SFX.GetComponent<AudioSource>().clip = SFXAudio;
        SFX.SetActive(true);
    }
}
