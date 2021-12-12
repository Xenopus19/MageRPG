using UnityEngine;

public class TurningDeathStatus : MonoBehaviour
{
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject gameUI;
    
    public void TurnOnDeathStatus(GameObject Player) {
        deathUI.SetActive(true);
        gameUI.SetActive(false);
        Destroy(Player.GetComponent<Animator>());
        Destroy(Player.GetComponent<PlayerHP>());
        Destroy(Player.GetComponent<GotDamageEffect>());
        Destroy(Player.GetComponent<PlayerHPText>());
        Destroy(Player.GetComponent<ManaPlayer>());
        Destroy(Player.GetComponent<ManaText>());
        Destroy(Player.GetComponent<SpellCast>());
        Destroy(Player.GetComponent<SpellIconsChange>());
        Destroy(Player.GetComponent<BasicShot>());
        Destroy(Player.GetComponent<AboveObjectHPBar>());
    }
}
