using UnityEngine;
using UnityEngine.SceneManagement;

public class HPPlayer : MonoBehaviour {
    /*public GameObject objectOfAttackPrefab;
    void OnTriggerEnter(Collider objectOfAttackInTriggerZone) {
        GameObject attack = Instantiate(objectOfAttackPrefab, objectOfAttackInTriggerZone.transform.position, objectOfAttackInTriggerZone.transform.rotation);
        Destroy(objectOfAttackInTriggerZone.gameObject);
        GetDamage();
    } */
    public float hpPlayer = 100f;
    public void GetDamage(float damage) {
        if (hpPlayer - damage > 0) {
            hpPlayer -= damage;
        } else {
            SceneManager.LoadScene("Death");
        }
        //PlayerHPText.ChangeHealthText(hpPlayer);
    }
}
