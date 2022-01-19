using UnityEngine.UI;
using UnityEngine;

public class SpellcodesTipsSpawner : MonoBehaviour
{
    [SerializeField] private Sprite[] spellcodes;
    [SerializeField] private Image FirstPanel;
    [SerializeField] private Image SecondPanel;

    private void OnEnable()
    {
        SetImageOnPanel(FirstPanel);
        SetImageOnPanel(SecondPanel);
        while(SecondPanel.sprite.Equals(FirstPanel.sprite))
        {
            SetImageOnPanel(SecondPanel);
        }
    }

    private void SetImageOnPanel(Image panel)
    {
        int spellcodeIndex = Random.Range(0, spellcodes.Length);
        panel.sprite = spellcodes[spellcodeIndex];
    }
}
