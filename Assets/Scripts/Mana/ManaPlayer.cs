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
    } //����� ���� ������� � ����� ��� instantiate � ��������
    public void RecoveryMana() {
        time += Time.deltaTime;
        if (time > 1) {
            manaPlayer += 1f;
            time = 0f;
            ManaText.ChangeManaText(manaPlayer);
        }
    }
}
