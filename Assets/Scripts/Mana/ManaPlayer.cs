using UnityEngine;

public class ManaPlayer : MonoBehaviour 
{

    public float manaPlayer = 100f;

    [SerializeField] private float MaxMana = 100;
    private float time = 0f;
    void Update() {
        if (manaPlayer < MaxMana) 
            RecoveryMana();

    }
    public void DecrementMana(float RequiredMana) {
        manaPlayer -= RequiredMana;
        ManaText.ChangeManaText(manaPlayer);
    }

    public void RecoveryMana() {
        time += Time.deltaTime;
        if (time > 0.4) {
            manaPlayer += 1f;
            time = 0f;
            ManaText.ChangeManaText(manaPlayer);
        }
    }
}
