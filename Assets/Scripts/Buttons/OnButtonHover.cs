using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonHover : MonoBehaviour
{
    public ulong AmountToAdd;

    public void ifHoveredOn()
    {
        SpellCast.GetInstance().SpellCode *= 10;
        SpellCast.GetInstance().SpellCode += AmountToAdd;
        print(SpellCast.GetInstance().SpellCode);
    }
}
