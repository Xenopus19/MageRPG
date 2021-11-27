using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class GotDamagePlayerEffect : GotDamageEffect
{
    [SerializeField] private GameObject UIEffectGO;
    [SerializeField] private Sprite[] Splashes;
    [SerializeField] private PhotonView photonView;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        health.OnDamageReceived += FrontendEffects;
    }
    public override void FrontendEffects()
    {
        CreateParticleEffect();
        CreateUIEffect();
        PlaySound();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            health.ReceiveDamage(5);
    }
    private void CreateUIEffect()
    {
        if(photonView.IsMine)
        {
            GameObject canvas = GameObject.FindWithTag("EffectsCanvas");
            GameObject effect = Instantiate(UIEffectGO);
            effect.GetComponent<Image>().sprite = Splashes[Random.Range(0, Splashes.Length)];
            effect.transform.SetParent(canvas.transform);
            effect.transform.position = new Vector2(0, 0);
        }
    }
}
