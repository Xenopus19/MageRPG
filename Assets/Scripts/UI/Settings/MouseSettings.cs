using UnityEngine.UI;
using UnityEngine;

public class MouseSettings : MonoBehaviour
{
    [SerializeField] string PrefsKey = "MouseSensitivity";

    private MouseLook PlayerMouse;
    public Slider slider;

    public void Init(GameObject Player) {
        PlayerMouse = Player.GetComponentInChildren<MouseLook>();
        SetSensitivity(LoadValue());
        slider.value = LoadValue();
    }

    private void Update()
    {
        if(PlayerMouse == null)
        {
            if(PlayerNetwork.LocalPlayerGO!=null)
            {
                PlayerMouse = PlayerNetwork.LocalPlayerGO.GetComponentInChildren<MouseLook>();
                SetSensitivity(LoadValue());
            }
        }
    }
    public void ChangeSensitivity(Slider slider)
    {
        SetSensitivity(slider.value);
    }
    private void SetSensitivity(float Value)
    {
        PlayerMouse.mouseSensitivity = Value;
        SaveValue(Value);
    }

    private void SaveValue(float value)
    {
        PlayerPrefs.SetFloat(PrefsKey, value);
    }

    private float LoadValue()
    {
        if(PlayerPrefs.HasKey(PrefsKey))
        {
            Debug.Log("has");
            return PlayerPrefs.GetFloat(PrefsKey);
        }
        return 350f;
    }
}
