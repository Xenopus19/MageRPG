using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeVisualisations : MonoBehaviour
{
    public GameObject[] Icons;
    [SerializeField] private GameObject Canvas;
    public GameObject spawn;
    private List<int> CurrentCode;
    public void CodeRefresh(int CurrentCodeColision)
    {
        CurrentCode.Add(CurrentCodeColision);
        for (int i = 0; i < Icons.Length; i++)
        {
            if (CurrentCodeColision == i) Instantiate(Icons[i], spawn.transform.position, Quaternion.identity, Canvas.transform);
        }
    } 
}
