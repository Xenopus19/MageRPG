using Photon.Pun;
using UnityEngine;

public class Tutorial_GameGoal : MonoBehaviour
{
    [Header("Enemy Spawn")]
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform SpawnPoint;

    [Header("UI Elements")]
    [SerializeField] private GameObject GameGoalsExplanation;
    [SerializeField] private GameObject FinishTutorialScreen;

    private GameObject Enemy;
    private void Start()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        if(Enemy==null)
        {
            GameGoalsExplanation.SetActive(false);
            FinishTutorialScreen.SetActive(true);
        }
    }

    private void SpawnEnemy()
    {
        Enemy = PhotonNetwork.Instantiate(EnemyPrefab.name, SpawnPoint.position, Quaternion.identity);
    }

    public void HideTips()
    {
        FinishTutorialScreen.SetActive(false);
    }
}
