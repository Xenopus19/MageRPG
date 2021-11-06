using UnityEngine;
using UnityEngine.UI;

public class EndGameCanvasManager : MonoBehaviour {
    [SerializeField] private string winString;
    [SerializeField] private string loseString;
    [SerializeField] private GameObject endGameText;

    public void MakeWinText() {
        endGameText.GetComponent<Text>().text = winString;
    }

    public void MakeLoseText() {
        endGameText.GetComponent<Text>().text = loseString;
    }
}