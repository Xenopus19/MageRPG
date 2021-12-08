using UnityEngine;
using Photon.Pun;

public class ManaPlayer : MonoBehaviour 
{

    public float manaPlayer = 100f;
    public float MaxMana = 100;

    private float time = 0f;
    private PhotonView photonView;
    private ColorMana colorMana;
    private ManaText manaText;
    private void Start()
    {
        manaText = GetComponent<ManaText>();
        photonView = gameObject.GetComponent<PhotonView>();
        if (photonView.IsMine) {
            colorMana = GameObject.Find("PanelForMana").GetComponent<ColorMana>();
            colorMana.Init(gameObject);
        }
    }

    private void Update() 
    {
        if (manaPlayer < MaxMana) 
            RecoveryMana();
    }

    public void DecrementMana(float RequiredMana) 
    {
        manaPlayer -= RequiredMana;
        ChangeManaText();
    }
    public void RefillMana(float ManaToRefill)
    {
        manaPlayer += ManaToRefill;
        if (manaPlayer > MaxMana)
            manaPlayer = MaxMana;
        ChangeManaText();
    }

    public void RecoveryMana() 
    {
        time += Time.deltaTime;
        if (time > 0.4) {
            manaPlayer += 1f;
            time = 0f;
            ChangeManaText();
        }
    }

    private void ChangeManaText()
    {
        if(photonView.IsMine)
        manaText.ChangeManaText(manaPlayer);
    }

    public void DestroyToAvoidExceptions() {
        Destroy(this);
    }
}
