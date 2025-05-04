using UnityEngine;
using UnityEngine.UI;
public class SettingsSound : MonoBehaviour
{
    [SerializeField] GameObject settingsPanel;
    [SerializeField] Slider backgroundMusicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider SFXPlayerSlider;

    void Start()
    {
        GetVolumeValue(backgroundMusicSlider);
        GetVolumeValue(SFXSlider);
        GetVolumeValue(SFXPlayerSlider);
        backgroundMusicSlider.onValueChanged.AddListener(SoundSingleton.soundInstance.SettingBackgroundMusicVolume);
        SFXSlider.onValueChanged.AddListener(SoundSingleton.soundInstance.SettingSFXVolume);
        SFXPlayerSlider.onValueChanged.AddListener(SoundSingleton.soundInstance.SettingSFXPlayerVolume);
    }


    void GetVolumeValue(Slider slider)
    {
        if (slider == null) return;

        if (slider == backgroundMusicSlider)
        {
            slider.value = SoundSingleton.soundInstance.backgroundMusicVolume;
        }
        else if (slider == SFXSlider)
        {
            slider.value = SoundSingleton.soundInstance.SFXVolume;
        }
        else
        {
            slider.value = SoundSingleton.soundInstance.SFXPlayerVolume;
        }
    }

    public void OnSettings()
    {
        settingsPanel.gameObject.SetActive(!settingsPanel.gameObject.activeInHierarchy);
    }

}
