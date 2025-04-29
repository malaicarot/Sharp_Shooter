using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManagers : MonoBehaviour
{
    const string MAIN_SCENE = "Main";

    public void OnStart()
    {
        SceneManager.LoadScene(MAIN_SCENE);
    }

    public void OnSettings()
    {
        Debug.Log("Settings");
    }
    public void OnRestart()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void OnMainMenu(){
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
