using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBookPageScript : MonoBehaviour
{
    [SerializeField] private SpellBookPageDataScript ThisSpellData;
    private Text SpellName;
    private Image SpellIcon;
    private Text SpellDescription;
    private Text SpellManaCost;
    private Text SpellDamage;
    private Image SpellCastingCode;
    private void Start()
    {
        SpellName = gameObject.transform.Find("SpellName").GetComponent<Text>();
        SpellIcon = gameObject.transform.Find("SpellIcon").GetComponent<Image>();
        SpellDescription = gameObject.transform.Find("SpellDescription").GetComponent<Text>();
        SpellManaCost = gameObject.transform.Find("SpellManaCost").GetComponent<Text>();
        SpellDamage = gameObject.transform.Find("SpellDamage").GetComponent<Text>();
        SpellCastingCode = gameObject.transform.Find("SpellCastingCode").GetComponent<Image>();

        ChangeData(ThisSpellData);
    }

    public void ChangeData(SpellBookPageDataScript ThisSpellData)
    {
        SpellName.text = ThisSpellData.SpellName;
        SpellIcon.sprite = ThisSpellData.SpellImage;
        SpellDescription.text = ThisSpellData.SpellDescription;
        SpellManaCost.text = ThisSpellData.SpellManaCost;
        SpellDamage.text = ThisSpellData.SpellDamage;
        SpellCastingCode.sprite = ThisSpellData.SpellCastingCode;
    }
}
