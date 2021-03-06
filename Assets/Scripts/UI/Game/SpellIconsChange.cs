using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpellIconsChange : MonoBehaviour
{
    [SerializeField] private Transform ParticlesSpawnPoint;

    [SerializeField] private Sprite DefaultImage;

    [SerializeField] private GameObject IconPanel;
    [SerializeField]private Image IconImage;


    void Start()
    {
        if (!GetComponent<PhotonView>().IsMine) return;

        IconPanel = GameObject.Find("CurrentSpellPlane");
        IconPanel.SetActive(false);
        IconImage = IconPanel.GetComponent<Image>();
    }

    public void ChangeIcon(GameObject CurrentSpell)
    {
        Sprite CurrentSpellPicture;
        if(CurrentSpell!=null)
        {
            CurrentSpellPicture = CurrentSpell.GetComponent<Spell>().SpellIcon;
            IconPanel.SetActive(true);
        }
        else
        {
            CurrentSpellPicture = DefaultImage;
        }

        IconImage.sprite = CurrentSpellPicture;
    }
    public void SpawnParticles(GameObject CurrentSpell)
    {
        GameObject particle = Instantiate(CurrentSpell.GetComponent<Spell>().ParticlesOnRecognize, ParticlesSpawnPoint.position, Quaternion.identity);
        particle.transform.SetParent(ParticlesSpawnPoint);
    }

    public void DisableIconPanel()
    {
        IconPanel.SetActive(false);
    }
}
