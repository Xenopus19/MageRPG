using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeVisualisation : MonoBehaviour
{
    public GameObject[] Icons;
    [SerializeField] private GameObject Canvas;
    public GameObject spawn;
    public List<int> CurrentCode;
    public List<GameObject> CodeElements;
    public void CodeRefresh(int CurrentNewElement)
    {
        CurrentCode.Add(CurrentNewElement);
        Vector3 StatePosition = spawn.transform.position - new Vector3(0, CurrentCode.Count * 50, 0);
        GameObject CurentCreatedElement = Instantiate(Icons[CurrentNewElement - 1], StatePosition, Quaternion.identity, Canvas.transform);
        CodeElements.Add(CurentCreatedElement);
    }
    public void OnCastVisualisation()
    {
        for (int a = 0; a < CodeElements.Count; a++)
        {
            Destroy(CodeElements[a]);
        }
        CodeElements.Clear();
        CurrentCode.Clear();
    }
}