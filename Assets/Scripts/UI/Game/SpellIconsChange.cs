using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellIconsChange : MonoBehaviour
{
    [SerializeField] private Sprite DefaultImage;

    private GameObject IconPanel;
    private Image IconImage;
    private Sprite CurrentSpellIcon;

    private void Awake()
    {
        IconPanel = GameObject.FindGameObjectsWithTag("IconPanel")[0];
    }
    void Start()
    {
        CurrentSpellIcon = gameObject.GetComponent<SpellCast>().CurrentSpell.GetComponent<Spell>().SpellIcon;
        IconImage = IconPanel.GetComponent<Image>();
    }

    void Update()
    {
        if (CurrentSpellIcon != null)
        {
            IconImage.sprite = CurrentSpellIcon;
        }
        else
        {
            if(IconImage != null)
            {
                IconImage.sprite = DefaultImage;
            }
            else
            {
                Debug.Log("Sdfsdg");
            }
        }
    }
}
