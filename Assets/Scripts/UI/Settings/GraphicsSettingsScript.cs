using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class GraphicsSettingsScript : MonoBehaviour
{
    [Header("Settings Objects")]
    [SerializeField] private Toggle FullscreenToggleObject;
    [SerializeField] private Dropdown QualitySettingsObject;
    [SerializeField] private Dropdown ResolutionDropdown;

    private Resolution[] resolutions;
    private void Start()
    {
        FullscreenToggleObject.isOn = Screen.fullScreen;
        QualitySettingsObject.value = QualitySettings.GetQualityLevel();
        AddResolutionOptions();
        
    }
    private void AddResolutionOptions()
    {
        Resolution[] res = Screen.resolutions;
        resolutions= res.Distinct().ToArray();

        string[] stringResolutions = new string[resolutions.Length];

        for (int i = 0; i < stringResolutions.Length; i++)
        {
            stringResolutions[i] = resolutions[i].ToString();
        }

        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(stringResolutions.ToList());
    }
    public void SetResolution()
    {
        Screen.SetResolution(resolutions[ResolutionDropdown.value].width, resolutions[ResolutionDropdown.value].height, true);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
