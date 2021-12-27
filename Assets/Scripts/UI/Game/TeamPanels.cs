using UnityEngine;

public class TeamPanels : MonoBehaviour
{
    public GameObject yourTeamPanel;
    public GameObject enemyTeamPanel;
    private KeyCode codeActivityPanel = KeyCode.Tab;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(codeActivityPanel)) {
            if (yourTeamPanel.activeSelf == true) {
                audioSource.Play();
                yourTeamPanel.SetActive(false);
                enemyTeamPanel.SetActive(false);
            } else {
                yourTeamPanel.SetActive(true);
                enemyTeamPanel.SetActive(true);
            }
        }
    }
}
