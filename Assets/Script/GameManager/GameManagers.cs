using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagers : MonoBehaviour
{

    public void OnRestart()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void OnApplicationQuit() {
        Debug.LogWarningFormat("U R Quit!");
        Application.Quit();
    }
}
