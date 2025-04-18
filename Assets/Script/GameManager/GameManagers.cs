using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagers : MonoBehaviour
{
    [SerializeField] GameObject winerPanel;
    [SerializeField] TextMeshProUGUI enemyLeftTextmeshPro;

    const string ENEMY_LEFT = "Enemy Left";
    int enemyLeft;
    public void AdjustEnemy(int amount)
    {
        enemyLeft += amount;
        if (enemyLeft <= 0)
        {
            winerPanel.SetActive(true);
        }
        enemyLeftTextmeshPro.text = $"{ENEMY_LEFT}: {enemyLeft}";

    }

    public void OnRestart()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }

    public void OnApplicationQuit()
    {
        Debug.LogWarningFormat("U R Quit!");
        Application.Quit();
    }
}
