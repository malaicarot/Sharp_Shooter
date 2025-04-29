using System.Collections;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.ProBuilder;
using UnityEngine.SceneManagement;


public class GameManagers : MonoBehaviour
{
    public static GameManagers Instance;
    [SerializeField] GameObject winerPanel;
    [SerializeField] TextMeshProUGUI enemyLeftTextmeshPro;
    [SerializeField] ProBuilderMesh ceiling;
    [SerializeField] Vector3 bossPosition;
    [SerializeField] GameObject boss;
    [SerializeField] PlayableDirector playable;

    const string ENEMY_LEFT = "Enemy Left";
    const string BOSS_ATTEND = "BOSS WILL APPEAR!";
    int enemyLeft;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        BossActive(false);
    }

    void BossActive(bool status)
    {
        NavMeshAgent navMeshAgent = boss.GetComponent<NavMeshAgent>();
        Robot robot = boss.GetComponent<Robot>();
        navMeshAgent.enabled = status;
        robot.enabled = status;
    }
    void BossAppear()
    {
        ceiling.gameObject.SetActive(false);
        StartCoroutine(WaitForMusic());
        playable.Play();
        StartCoroutine(BossFight());
        BossActive(true);
    }

    IEnumerator BossFight()
    {
        yield return new WaitForSeconds(3);
    }
    IEnumerator WaitForMusic()
    {
        yield return new WaitForSeconds(2);
        SoundSingleton.soundInstance.PlayBackgroundMusic(3);
    }

    public void Winner()
    {
        winerPanel.SetActive(true);
        StarterAssetsInputs starterAssets = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssets.SetCursorState(false);
        SoundSingleton.soundInstance.PlayBackgroundMusic(4);
    }
    public void AdjustEnemy(int amount)
    {
        enemyLeft += amount;
        if (enemyLeft <= 0)
        {
            enemyLeftTextmeshPro.text = $"{BOSS_ATTEND}";
            BossAppear();
        }
        else
        {
            enemyLeftTextmeshPro.text = $"{ENEMY_LEFT}: {enemyLeft}";
        }
    }
}
