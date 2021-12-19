using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class AboveObjectHPBar : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject AboveText;
    [SerializeField] private GameObject TextPrefab;
    [SerializeField] private float DistanceBetweenTextAndObject;

    private GameObject HPText;
    private Health health;

    public bool InFirstTeam;
    void Start()
    {
        SpawnUpperText();
        health = gameObject.GetComponent<Health>();
    }

    void Update()
    {
        if (health.CurrentHealth <= 0) {
            HPText.GetComponent<TextMesh>().text = "Dead";
        } else {
            HPText.GetComponent<TextMesh>().text = health.CurrentHealth.ToString();
        }
    }

    private void SpawnUpperText()
    {
        if(AboveText==null)
        {
            Vector3 TextPos = gameObject.transform.position;
            TextPos.y += DistanceBetweenTextAndObject;

            Quaternion TextRotation = gameObject.transform.rotation;

            HPText = Instantiate(TextPrefab, TextPos, TextRotation);
            HPText.transform.SetParent(transform);
        }
        else
        {
            HPText = AboveText;
        }
    }
}
