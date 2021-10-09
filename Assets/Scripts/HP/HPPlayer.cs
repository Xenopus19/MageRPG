using UnityEngine;

public class HPPlayer : MonoBehaviour {
    public  static float hpPlayer = 100f;
    public GameObject objectOfAttackPrefab;
    void OnTriggerEnter(Collider objectOfAttackInTriggerZone) {
        GameObject attack = Instantiate(objectOfAttackPrefab, objectOfAttackInTriggerZone.transform.position, objectOfAttackInTriggerZone.transform.rotation);
        Destroy(objectOfAttackInTriggerZone.gameObject);
        GetDamage();
        HPText.ChangeHealthText(hpPlayer);
    }
    private void GetDamage() {
        if (hpPlayer > 0) {
            hpPlayer -= 10;
        } else {
            print("You are not deathless, so game over");
            Destroy(gameObject);
        }
    }
}
