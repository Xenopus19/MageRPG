using UnityEngine;

public class PanelsToggle : MonoBehaviour
{
    [SerializeField] private AudioSource Sourse;

    [Header("Team Planes")]
    [SerializeField] private GameObject yourTeamPanel;
    [SerializeField] private GameObject enemyTeamPanel;

    [Header("Exit Menu")]
    [SerializeField] private GameObject ExitMenu;

    private KeyCode TeamPanelsKey = KeyCode.Tab;
    private KeyCode ExitPanelKey = KeyCode.Escape;

    
    void Update()
    {
        ToggleTeamPlanes();
        ToggleExitPanel();
    }

    private void ToggleTeamPlanes()
    {
        if(Input.GetKeyDown(TeamPanelsKey))
        {
            bool NewState = !yourTeamPanel.activeInHierarchy;
            yourTeamPanel.SetActive(NewState);
            enemyTeamPanel.SetActive(NewState);
            Sourse.Play();
        }
    }

    private void ToggleExitPanel()
    {
        if(Input.GetKeyDown(ExitPanelKey))
        {
            bool NewState = !ExitMenu.activeInHierarchy;
            Sourse.Play();
            ExitMenu.SetActive(NewState);
            Cursor.lockState = NewState ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
