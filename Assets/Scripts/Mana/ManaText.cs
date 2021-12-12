using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
[RequireComponent(typeof(ManaPlayer))]
public class ManaText : MonoBehaviour
{
    [SerializeField] private float PercentLeftToDisplayIcons;
    

    private float UpperValueToDisplayIcons;

    private GameObject ManaBar;
    private PhotonView photonView;
    private GameObject LowManaIcons;


    private void Start()
    {
        UpperValueToDisplayIcons = Percent(GetComponent<ManaPlayer>().MaxMana, PercentLeftToDisplayIcons);

        photonView = gameObject.GetComponent<PhotonView>();
        if(photonView.IsMine)
        {
            ManaBar = GameObject.Find("ManaText");
            LowManaIcons = GameObject.Find("LowManaBar");
            LowManaIcons.SetActive(false);
        } 
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
            LowManaIcons?.SetActive(true);
        }
        else
        {
            LowManaIcons?.SetActive(false);
        }
    }
}
