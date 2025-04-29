using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundSingleton : MonoBehaviour
{
    [SerializeField] AudioClip[] audioMusicClip;
    [SerializeField] AudioClip[] audioSFXClip;

    AudioSource backgroundMusicSource;
    AudioSource SFXSource;

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
    }


    public void PlayBackgroundMusic(int index)
    {
        // int index = SceneManager.GetActiveScene().buildIndex;
        PlayAudioClip(backgroundMusicSource, audioMusicClip[index]);
    }

    public void PlaySFX(int index)
    {
        PlayAudioClip(SFXSource, audioSFXClip[index]);

    }


    void PlayAudioClip(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Stop();
        audioSource.Play();
    }
}
