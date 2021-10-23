using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliders : MonoBehaviour
{
    private string MusicExposedParam = "Music";
    private string EffectsExposedParam = "Effects";

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private int VolumeMultiplier;

    private void Start()
    {
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            SetGroupVolume(MusicExposedParam, PlayerPrefs.GetFloat("MusicVolume"));
        }

        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            SetGroupVolume(EffectsExposedParam, PlayerPrefs.GetFloat("EffectsVolume"));
        }
    }

    public void SetGroupVolume(string ExposedParam, float newVolume)
    {
        audioMixer.SetFloat(ExposedParam, LerpSliderValue(newVolume));
    }

    public void ChangeMusicVolume(Slider slider)
    {
        SetGroupVolume(MusicExposedParam, slider.value);
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }
    public void ChangeEffectVolume(Slider slider)
    {
        SetGroupVolume(EffectsExposedParam, slider.value);
        PlayerPrefs.SetFloat("EffectsVolume", slider.value);
    }

    private float LerpSliderValue(float value)
    {
        if(value == 0)
        {
            return -80;
        }
        else
        {
            return 20f * Mathf.Log10(value);
        }
    }
}
