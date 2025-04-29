using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagers : MonoBehaviour
{
    public static GameManagers Instance;
    [SerializeField] GameObject winerPanel;
    [SerializeField] TextMeshProUGUI enemyLeftTextmeshPro;

    const string ENEMY_LEFT = "Enemy Left";
    int enemyLeft;

    void Awake()
    {
        // if (Instance != null && Instance != this)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
         if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        // Instance = this;
        // DontDestroyOnLoad(gameObject);
    }

    public void AdjustEnemy(int amount)
    {
        enemyLeft += amount;
        if (enemyLeft <= 0)
        {
            winerPanel.SetActive(true);
            StarterAssetsInputs starterAssets = FindFirstObjectByType<StarterAssetsInputs>();
            starterAssets.SetCursorState(false);
            SoundSingleton.soundInstance.PlayBackgroundMusic(4);
        }
        enemyLeftTextmeshPro.text = $"{ENEMY_LEFT}: {enemyLeft}";
    }
}
