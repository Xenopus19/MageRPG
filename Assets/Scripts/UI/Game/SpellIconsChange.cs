using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellIconsChange : MonoBehaviour
{
    [SerializeField] private Sprite DefaultImage;

    [SerializeField] private GameObject IconPanel;
    [SerializeField]private Image IconImage;

    private SpellCast spellCast;

    void Start()
    {
        spellCast = GetComponent<SpellCast>();
        //IconPanel = GameObject.FindGameObjectsWithTag("IconPanel")[0];
        IconImage = IconPanel.GetComponent<Image>();
    }

    public void ChangeIcon(GameObject CurrentSpell)
    {
        Sprite CurrentSpellPicture;
        if(CurrentSpell!=null)
        {
            CurrentSpellPicture = CurrentSpell.GetComponent<Spell>().SpellIcon;
        }
        else
        {
            CurrentSpellPicture = DefaultImage;
        }

        IconImage.sprite = CurrentSpellPicture;
    }
}
