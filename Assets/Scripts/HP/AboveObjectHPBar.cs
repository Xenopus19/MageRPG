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
    private Health playerHP;
    private float health;
    private PhotonView _photonView;

    public bool InFirstTeam;
    void Start()
    {
        SpawnUpperText();
        _photonView = GetComponent<PhotonView>();
        playerHP = gameObject.GetComponent<Health>();
    }

    void Update() {
        if (_photonView.IsMine) {
            health = playerHP.CurrentHealth;
            photonView.RPC("ShowHealth", RpcTarget.All, health);
        }
    }

    [PunRPC]
    public void ShowHealth(float health) 
    {
        if (health >= 0) 
        {
            HPText.GetComponent<TextMesh>().text = health.ToString();
        } 
        else 
        {
            HPText.GetComponent<TextMesh>().text = "Dead";
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
