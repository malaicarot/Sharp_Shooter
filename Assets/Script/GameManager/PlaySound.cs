using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySound : MonoBehaviour
{
    
    
    void Start()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        SoundSingleton.soundInstance.PlayBackgroundMusic(index);
    }
}
