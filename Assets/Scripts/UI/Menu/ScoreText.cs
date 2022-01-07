using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    private float score = 0;
    void Start() {
        if (!PlayerPrefs.HasKey("Score")) {
            PlayerPrefs.SetFloat("Score", 0);
        }

        score = PlayerPrefs.GetFloat("Score");
        gameObject.GetComponent<Text>().text = $"Victories: {score}";
        Debug.Log($"Start{score}");
    }

    public void SaveScore() {
        score = PlayerPrefs.GetFloat("Score") + 1;
        PlayerPrefs.SetFloat("Score", score);
        Debug.Log($"SaveScore{score}");
        ShowScore();
    }

    private void ShowScore() {
        gameObject.GetComponent<Text>().text = $"Victories: {score}";
    }
}
