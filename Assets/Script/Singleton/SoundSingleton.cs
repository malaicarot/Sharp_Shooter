using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSingleton : MonoBehaviour
{
    [SerializeField] AudioClip[] audioMusicClip;
    [SerializeField] AudioClip[] audioSFXClip;
    [SerializeField] AudioClip[] audioSFXPlayerClip;
    [SerializeField] AudioClip[] audioSoundGunClip;

    AudioSource backgroundMusicSource;
    AudioSource SFXSource;
    AudioSource SFXPlayerSource;
    AudioSource soundGunSource;



    public float backgroundMusicVolume;
    public float SFXVolume;
    public float SFXPlayerVolume;


    public static SoundSingleton soundInstance;
    void Awake()
    {
        if (soundInstance == null)
        {
            soundInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        backgroundMusicSource = GetComponents<AudioSource>()[0];
        SFXSource = GetComponents<AudioSource>()[1];
        SFXPlayerSource = GetComponents<AudioSource>()[2];
        soundGunSource = GetComponents<AudioSource>()[3];

        GetVolumeValue();
    }



    void GetVolumeValue()
    {
        /*Get volume value from PlayerPrefs*/
        backgroundMusicVolume = PlayerPrefs.GetFloat("BackgroundMusic", 0.5f);
        SFXVolume = PlayerPrefs.GetFloat("SFX", 0.5f);
        SFXPlayerVolume = PlayerPrefs.GetFloat("SFXPlayer", 0.5f);

        /*Set default volume value*/
        backgroundMusicSource.volume = backgroundMusicVolume;
        SFXSource.volume = SFXVolume;
        SFXPlayerSource.volume = SFXPlayerVolume;
    }


    // Set Volume
    public void SettingBackgroundMusicVolume(float _soundVolume)
    {
        backgroundMusicVolume = _soundVolume;
        backgroundMusicSource.volume = backgroundMusicVolume;
        PlayerPrefs.SetFloat("BackgroundMusic", backgroundMusicVolume);
        PlayerPrefs.Save();
    }

    public void SettingSFXVolume(float _soundVolume)
    {
        SFXVolume = _soundVolume;
        SFXSource.volume = SFXVolume;

        soundGunSource.volume = SFXVolume;

        PlayerPrefs.SetFloat("SFX", SFXVolume);

        PlayerPrefs.Save();
    }

    public void SettingSFXPlayerVolume(float _soundVolume)
    {
        SFXPlayerVolume = _soundVolume;
        SFXPlayerSource.volume = SFXPlayerVolume;
        PlayerPrefs.SetFloat("SFXPlayer", SFXPlayerVolume);
        PlayerPrefs.Save();
    }

    // Play Sound
    public void PlayBackgroundMusic(int index)
    {
        PlayAudioClip(backgroundMusicSource, audioMusicClip[index]);
    }

    public void PlaySFX(int index)
    {
        PlayAudioClip(SFXSource, audioSFXClip[index]);

    }


    public void PlaySFXPlayer(int index)
    {
        PlayAudioClip(SFXPlayerSource, audioSFXPlayerClip[index]);

    }

    public void PlaySoundGun(int index)
    {
        PlayAudioClip(soundGunSource, audioSoundGunClip[index]);

    }

    void PlayAudioClip(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Stop();
        audioSource.Play();
    }
}
