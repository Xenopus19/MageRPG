using UnityEngine;

public class ManaPlayer : MonoBehaviour {
    public float manaPlayer = 100f;
    private float time = 0f;
    void Update() {
        if (manaPlayer < 100) 
            RecoveryMana();

    }
    public void DecrementMana() {
        manaPlayer -= 20f;
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
