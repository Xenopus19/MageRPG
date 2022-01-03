using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGlowing : MonoBehaviour
{
    public static int GlowingsAmount = 0;

    [SerializeField] private List<Color> colors;
    private ButtonsGlowingManager glowingManager;
    private void Start()
    {
        glowingManager = GameObject.Find("ButtonsGlowingManager").GetComponent<ButtonsGlowingManager>();
        GlowingsAmount += 1;
        GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        SetColor();
    }
    private void Update()
    {
        if(glowingManager.WasEraseKeyPressed)
        {
            GlowingsAmount -= 1;
            if (GlowingsAmount == 0)
                glowingManager.WasEraseKeyPressed = false;
            Destroy(gameObject);
        }
    }

    private void SetColor()
    {
        Image image = GetComponent<Image>();

        image.color = colors[GetColorIndex()];
    }

    private int GetColorIndex()
    {
        return GlowingsAmount % colors.Count;
    }
}
