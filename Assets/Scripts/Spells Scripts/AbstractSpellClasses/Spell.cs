using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Spell : MonoBehaviour
{
    public GameObject Caster;
    public float ActionAmount;
    public float ManaConsumption;
    public Sprite SpellIcon;
    public Animator anim;

    public void GetAnimator()
    {
        anim = Caster.GetComponent<Animator>();
    }
}
