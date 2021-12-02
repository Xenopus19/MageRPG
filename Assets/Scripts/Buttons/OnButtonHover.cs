using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnButtonHover : MonoBehaviour
{
    public int AmountToAdd;

    public SpellCodeVisualisation SpellCodeVisualisation;

    public SpellCast spellCast;
    private void Start()
    {
        if (!GetComponent<PhotonView>().IsMine) return;
        SpellCodeVisualisation = GetComponent<SpellCodeVisualisation>();
    }
    public void ifHoveredOn()
    {
        spellCast.SpellCode *= 10;
        SpellCodeVisualisation.CodeRefresh(AmountToAdd);
        spellCast.SpellCode += AmountToAdd;
        print(spellCast.SpellCode);
    }
}
