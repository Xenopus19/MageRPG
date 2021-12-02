using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnButtonHover : MonoBehaviour
{
    public int AmountToAdd;
    public GameObject[] Icons;
    [SerializeField] private GameObject Canvas;
    public GameObject spawn;
    public List<float> CurrentCode;

    public SpellCast spellCast; 

    public void ifHoveredOn()
    {
        spellCast.SpellCode *= 10;
        CodeRefresh(AmountToAdd);
        spellCast.SpellCode += AmountToAdd;
        print(spellCast.SpellCode);
    }
    public void CodeRefresh(int CurrentNewElement)
    {
        CurrentCode.Add(CurrentNewElement);
        Instantiate(Icons[CurrentNewElement], spawn.transform.position, Quaternion.identity, Canvas.transform);
    }
}
