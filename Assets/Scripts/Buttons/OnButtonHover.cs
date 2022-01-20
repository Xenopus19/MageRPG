using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnButtonHover : MonoBehaviour
{
    public int AmountToAdd;

    public SpellCast spellCast;

    [SerializeField] private GameObject GlowingPrefab;
    public void ifHoveredOn()
    {
        if (spellCast == null) return;
        {
            if (!spellCast.SpellCode.EndsWith(AmountToAdd.ToString()))
            {
                spellCast.SpellCode += AmountToAdd.ToString();
                if(transform.childCount==0)
                CreateGlowingEffect();
            }
        }

        
        Debug.Log(spellCast.SpellCode);
    }

    private void CreateGlowingEffect()
    {
        Instantiate(GlowingPrefab, gameObject.transform);
    }
}
