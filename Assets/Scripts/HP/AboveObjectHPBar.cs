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
        //RemoveHPBarsOfOtherTeam();
    }

    void Update()
    {
        HPText.GetComponent<TextMesh>().text = health.CurrentHealth.ToString();
        //RotateOtherHPBarsToPlayer();
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

    private void RemoveHPBarsOfOtherTeam()
    {
        foreach(Player player in PhotonNetwork.PlayerListOthers)
        {
            GameObject Player = (GameObject)player.TagObject;
            AboveObjectHPBar OtherPlayerScript = Player.GetComponent<AboveObjectHPBar>();
            if(OtherPlayerScript.InFirstTeam != gameObject.GetComponent<AboveObjectHPBar>())
            {
                Destroy(OtherPlayerScript.HPText);
            }
        }
    }

    /*private void RotateOtherHPBarsToPlayer()
    {
        foreach (Player player in PhotonNetwork.PlayerListOthers)
        {
            GameObject Player = (GameObject)player.TagObject;
            AboveObjectHPBar OtherPlayerScript = Player.GetComponent<AboveObjectHPBar>();
            OtherPlayerScript.HPText.transform.LookAt(transform);
        }
    }*/
}
