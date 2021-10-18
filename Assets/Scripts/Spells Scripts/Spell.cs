using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSpell", menuName = "ScriptableObjects/SpellScriptableObject", order = 1)]
public class Spell : ScriptableObject
{
    public float Damage;
    public float ManaConsumption;
    public Image SpellIcon;
}
