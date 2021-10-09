using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPlayer : MonoBehaviour {
    public static float manaPlayer = 100f;
    private float time = 0f;
    void Update() {
        if (manaPlayer < 100) {
            RecoveryMana();
        }
    }
    public void DecrementMana() {
        manaPlayer -= 20f;
        ManaText.ChangeManaText(manaPlayer);
    } //вызов этой функции в месте где instantiate у фаербола
    public void RecoveryMana() {
        time += Time.deltaTime;
        if (time > 0.4) {
            manaPlayer += 1f;
            time = 0f;
            ManaText.ChangeManaText(manaPlayer);
        }
    }
}
