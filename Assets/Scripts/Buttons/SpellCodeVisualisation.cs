using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeVisualisation : MonoBehaviour
{
    public GameObject[] Icons;
    [SerializeField] private GameObject Canvas;
    public GameObject spawn;
    private List<int> CurrentCode;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CodeRefresh(int CurrentCodeColision)
    {
        CurrentCode.Add(CurrentCodeColision);
        for (int i = 0; i < Icons.Length; i++)
        {
            if (CurrentCodeColision == i) Instantiate(Icons[i], spawn.transform.position, Quaternion.identity, Canvas.transform);
        }
    }
}

