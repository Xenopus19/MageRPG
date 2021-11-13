using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New SpellBook Page", menuName = "SpellBook Page Data", order = 51)]
public class SpellBookPageDataScript : ScriptableObject
{
    public string SpellName;
    public Sprite SpellImage;
    public string SpellDescription;
    public string SpellManaCost;
    public string SpellDamage;
    public Sprite SpellCastingCode;
}
