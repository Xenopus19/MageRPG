using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnButtonHover : MonoBehaviour
{
    public int AmountToAdd;

    public SpellCast spellCast;

    public void ifHoveredOn()
    {
        //spellCast.SpellCode *= 10;
        spellCast.SpellCode = spellCast.SpellCode + AmountToAdd.ToString();
        Debug.Log(spellCast.SpellCode);
    }
}
