using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GraphicsSettingsScript : MonoBehaviour
{
    [Header("Settings Objects")]
    [SerializeField] private Toggle FullscreenToggleObject;
    [SerializeField] private Dropdown QualitySettingsObject;
    [SerializeField] private Dropdown ResolutionDropdown;

    private bool LastFullScreenSettings;
    private Resolution[] resolutions;
    private void Start()
    {
        LastFullScreenSettings = Screen.fullScreen;
        FullscreenToggleObject.isOn = Screen.fullScreen;
        QualitySettingsObject.value = QualitySettings.GetQualityLevel();
        AddResolutionOptions();
        if (!PlayerPrefs.HasKey("QualityLevel")) 
        {
            PlayerPrefs.SetInt("QualityLevel", QualitySettingsObject.value);
        }
        else 
        {
            QualitySettingsObject.value = PlayerPrefs.GetInt("QualityLevel");
        }
    }
    private void Update()
    {
        if(LastFullScreenSettings != Screen.fullScreen)
        {
            FullscreenToggleObject.isOn = Screen.fullScreen;
            LastFullScreenSettings = Screen.fullScreen;
        }
    }
    private void AddResolutionOptions()
    {
        Resolution[] res = Screen.resolutions;
        resolutions = res.Distinct().ToArray();

        string[] stringResolutions = new string[resolutions.Length];

        for (int i = 0; i < stringResolutions.Length; i++)
        {
            stringResolutions[i] = resolutions[i].ToString();
        }

        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(stringResolutions.ToList());

        if (PlayerPrefs.HasKey("Resolution")) 
        { 
            Debug.Log("has");
            ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
        }
    }
    public void SetResolution()
    {
        Screen.SetResolution(resolutions[ResolutionDropdown.value].width, resolutions[ResolutionDropdown.value].height, true);
        PlayerPrefs.SetInt("Resolution", ResolutionDropdown.value);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
