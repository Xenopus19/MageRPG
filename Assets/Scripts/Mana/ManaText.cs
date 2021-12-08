using UnityEngine.UI;
using UnityEngine;
[RequireComponent(typeof(ManaPlayer))]
public class ManaText : MonoBehaviour
{
    [SerializeField] private float PercentLeftToDisplayIcons;

    private float UpperValueToDisplayIcons;

    private GameObject ManaBar;
    private GameObject LittleManaIcons;

    private void Start()
    {
        UpperValueToDisplayIcons = Percent(GetComponent<ManaPlayer>().MaxMana, PercentLeftToDisplayIcons);

        ManaBar = GameObject.Find("ManaText");
        LittleManaIcons = GameObject.Find("LittleManaIcons");
    }

    public void ChangeManaText(float manaPlayer) 
    {
        ManageIcons(manaPlayer);
        ManaBar.GetComponent<Text>().text = $"{manaPlayer}";
    }

    public float Percent(float Number, float Percent) // Потом вынести в Extension для Mathf.
    {
        return Number / 100 * Percent;
    }

    private void ManageIcons(float manaPlayer)
    {
        if (manaPlayer <= UpperValueToDisplayIcons)
        {
            Debug.LogError("Icons are active.");
            LittleManaIcons?.SetActive(true);
        }
        else
        {
            Debug.LogError("Icons disabled.");
            LittleManaIcons?.SetActive(false);
        }
    }
}
