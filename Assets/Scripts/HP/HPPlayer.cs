using UnityEngine;

public class HPPlayer : MonoBehaviour {
    /*public GameObject objectOfAttackPrefab;
    void OnTriggerEnter(Collider objectOfAttackInTriggerZone) {
        GameObject attack = Instantiate(objectOfAttackPrefab, objectOfAttackInTriggerZone.transform.position, objectOfAttackInTriggerZone.transform.rotation);
        Destroy(objectOfAttackInTriggerZone.gameObject);
        GetDamage();
    } */
    public float hpPlayer = 100f;
    public void GetDamage(float damage) 
{
        if (hpPlayer > 0) {
            hpPlayer -= damage;
        } else {
            print("You are not deathless, so game over");
            Destroy(gameObject);
        }
        HPText.ChangeHealthText(hpPlayer);
    }
}
