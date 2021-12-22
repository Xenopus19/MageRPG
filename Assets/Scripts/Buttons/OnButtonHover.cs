using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnButtonHover : MonoBehaviour
{
    public int AmountToAdd;

    public SpellCast spellCast;
    //public SpellCodeVisualisation spellCodeVisualisation;

    public void Start()
    {
        //spellCodeVisualisation = GameObject.Find("buttons").GetComponent<SpellCodeVisualisation>();
    }
    public void ifHoveredOn()
    {
        //spellCast.SpellCode *= 10;
        if(!spellCast.SpellCode.EndsWith(AmountToAdd.ToString()))
        spellCast.SpellCode += AmountToAdd.ToString();
        //spellCodeVisualisation.CodeRefresh(AmountToAdd);
        Debug.Log(spellCast.SpellCode);
    }
}
