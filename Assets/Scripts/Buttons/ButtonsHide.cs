using UnityEngine;
using Photon.Pun;

public class ButtonsHide : MonoBehaviour 

{
    public GameObject buttons;

    private PhotonView photonView;
    public void Start() 
    {
        photonView = gameObject.transform.GetComponentInParent<PhotonView>();

        if(photonView.IsMine)
        {
            SpellCast spellCast = GetComponentInParent<SpellCast>();
            buttons = GameObject.Find("buttons");
            for(int i = 0; i<buttons.transform.childCount; i++)
            {
                GameObject ButtonChild = buttons.transform.GetChild(i).gameObject;
                OnButtonHover buttonHover = ButtonChild.GetComponent<OnButtonHover>();
                if(buttonHover!=null)
                {
                    buttonHover.spellCast = spellCast;
                }
                //Debug.Log($"SpellCast for {i} set.");
            }
            buttons.SetActive(false);
        }
        
    }
    public void CloseButtons() 
    {
        if(photonView.IsMine)
        buttons.SetActive(false);
    }
    public void ShowButtons() 
    {
        if(photonView.IsMine)
        buttons.SetActive(true);
    }
}
