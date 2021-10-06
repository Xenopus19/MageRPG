using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellCast : MonoBehaviour
{
    private static SpellCast Instance;
    public static SpellCast GetInstance() => Instance;
    private void Awake()
    {
        Instance = this;
    }
    public int SpellCode;
    private void Start()
    {
        SpellCode = 0;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) SpellCode = 0;
    }
}
