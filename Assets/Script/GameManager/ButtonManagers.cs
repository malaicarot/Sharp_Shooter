using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManagers : MonoBehaviour
{
    // [SerializeField] GameObject settingsPanel;
    // [SerializeField] Slider backgroundMusicSlider;
    // [SerializeField] Slider SFXSlider;
    // [SerializeField] Slider SFXPlayerSlider;
    const string MAIN_SCENE = "Main";


    // void Start()
    // {
    //     GetVolumeValue(backgroundMusicSlider);
    //     GetVolumeValue(SFXSlider);
    //     GetVolumeValue(SFXPlayerSlider);
    //     backgroundMusicSlider.onValueChanged.AddListener(SoundSingleton.soundInstance.SettingBackgroundMusicVolume);
    //     SFXSlider.onValueChanged.AddListener(SoundSingleton.soundInstance.SettingSFXVolume);
    //     SFXPlayerSlider.onValueChanged.AddListener(SoundSingleton.soundInstance.SettingSFXPlayerVolume);
    // }


    // void GetVolumeValue(Slider slider)
    // {
    //     if (slider == null) return;

    //     if (slider == backgroundMusicSlider)
    //     {
    //         slider.value = SoundSingleton.soundInstance.backgroundMusicVolume;
    //     }
    //     else if (slider == SFXSlider)
    //     {
    //         slider.value = SoundSingleton.soundInstance.SFXVolume;
    //     }
    //     else
    //     {
    //         slider.value = SoundSingleton.soundInstance.SFXPlayerVolume;
    //     }
    // }



    public void OnStart()
    {
        SceneManager.LoadScene(MAIN_SCENE);
    }

    // public void OnSettings()
    // {
    //     settingsPanel.gameObject.SetActive(!settingsPanel.gameObject.activeInHierarchy);
    // }
    public void OnRestart()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
