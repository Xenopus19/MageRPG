using UnityEngine;

public class RecommendationPanel : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("IsFirstTime") && PlayerPrefs.GetInt("IsFirstTime") == 1) {
            gameObject.SetActive(false);
        } else {
            PlayerPrefs.SetInt("IsFirstTime", 0);
        }
    }

    public void TurnOffPanel() {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("IsFirstTime", 1);
    }
}
