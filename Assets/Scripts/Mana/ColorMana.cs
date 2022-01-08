using UnityEngine;
using UnityEngine.UI;

public class ColorMana : MonoBehaviour {
    [SerializeField] Gradient ManaGradient;
    [SerializeField] Image ManaBarImage;

    private float manaPercent;

    private float CurrentMana;
    private float MaxMana;

    private ManaPlayer playerMana;
    public void Init(GameObject player) {
        playerMana = player.GetComponent<ManaPlayer>();
    }
    void Update() {
        if (playerMana != null)
        {
            CurrentMana = playerMana.manaPlayer;
            MaxMana = playerMana.MaxMana;
            manaPercent = CurrentMana / MaxMana;
            ManaBarImage.color = ManaGradient.Evaluate(manaPercent);
            ManaBarImage.fillAmount = manaPercent;
        }
    }
}
