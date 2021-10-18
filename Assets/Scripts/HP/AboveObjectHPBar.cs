using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class AboveObjectHPBar : MonoBehaviour
{
    [SerializeField] private TextMesh TextPrefab;
    [SerializeField] private float DistanceBetweenTextAndObject;
    [SerializeField] private float TextDeltaRotation;

    private TextMesh Text;
    private Health health;
    void Start()
    {
        SpawnUpperText();
        health = gameObject.GetComponent<Health>();
    }

    void Update()
    {
        Text.text = health.CurrentHealth.ToString();
    }

    private void SpawnUpperText()
    {
        Vector3 TextPos = gameObject.transform.position;
        TextPos.y += DistanceBetweenTextAndObject;

        Quaternion TextRotation = gameObject.transform.rotation;
        TextRotation.w += TextDeltaRotation;

        Text = Instantiate(TextPrefab, TextPos, TextRotation);
    }
}
