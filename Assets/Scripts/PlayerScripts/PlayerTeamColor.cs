using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamColor : MonoBehaviour
{
    [SerializeField] private Light TeamHalo;

    private void Start()
    {
        bool team = GetComponent<PlayerNetwork>().team;
        bool LocalPlayerTeam = PlayerNetwork.LocalPlayerGO.GetComponent<PlayerNetwork>().team;


        if(team != LocalPlayerTeam)
        {
            TeamHalo.color = Color.red;
        }
    }
}
