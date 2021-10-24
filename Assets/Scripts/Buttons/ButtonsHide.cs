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
            buttons = GameObject.Find("buttons");
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
