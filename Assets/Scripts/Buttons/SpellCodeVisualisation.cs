using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCodeVisualisation : MonoBehaviour
{
    public Transform[] IconsPosition;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject Canvas;
    public List<int> CurrentCode;
    public List<GameObject> CodeElements;
    public void CodeRefresh(int CurrentNewElement)
    {
        if(CurrentCode.Count>2)
        {
            CurrentCode.Add(CurrentNewElement);
            Vector3 Arrowvector = IconsPosition[CurrentNewElement - 1].position - IconsPosition[CurrentNewElement].position;
            Quaternion ArrowAngle = Quaternion.FromToRotation(Arrowvector, transform.forward);
            GameObject CurentCreatedElement = Instantiate(Arrow, IconsPosition[CurrentNewElement-1].position , ArrowAngle ,Canvas.transform);
            CodeElements.Add(CurentCreatedElement);
        }    
    }
    public void OnCastVisualisation ()
    {
        for (int a = 0; a < CodeElements.Count; a++)
        {
            Destroy(CodeElements[a]);
        }
        CodeElements.Clear();
        CurrentCode.Clear();
    }
}