using UnityEngine;

public class TeamPanels : MonoBehaviour
{
    public GameObject yourTeamPanel;
    public GameObject enemyTeamPanel;
    private KeyCode codeActivityPanel = KeyCode.Tab;
    void Update()
    {
        if (Input.GetKeyDown(codeActivityPanel)) {
            if (yourTeamPanel.activeSelf == true) {
                yourTeamPanel.SetActive(false);
                enemyTeamPanel.SetActive(false);
            } else {
                yourTeamPanel.SetActive(true);
                enemyTeamPanel.SetActive(true);
            }
        }
    }
}
