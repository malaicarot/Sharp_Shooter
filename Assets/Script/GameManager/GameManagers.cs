using System.Collections;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.ProBuilder;


public class GameManagers : MonoBehaviour
{
    public static GameManagers Instance;
    [SerializeField] GameObject winerPanel;
    [SerializeField] TextMeshProUGUI enemyLeftTextmeshPro;
    [SerializeField] GameObject ceiling;
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
        if(boss == null) return;
        NavMeshAgent navMeshAgent = boss.GetComponent<NavMeshAgent>();
        Robot robot = boss.GetComponent<Robot>();
        navMeshAgent.enabled = status;
        robot.enabled = status;
        Turret[] bossTurret = boss.GetComponentsInChildren<Turret>();
        foreach (var item in bossTurret)
        {
            item.enabled = status;
        }        
    }
    void BossAppear()
    {
        BossActive(true);
        ceiling.SetActive(false);
        StartCoroutine(WaitForMusic(3));
        // playable.Play();
        StartCoroutine(BossFight());

    }

    IEnumerator BossFight()
    {
        yield return new WaitForSeconds(3);
    }
    IEnumerator WaitForMusic(int index)
    {
        yield return new WaitForSeconds(2);
        SoundSingleton.soundInstance.PlayBackgroundMusic(index);
    }

    public void Winner()
    {
        winerPanel.SetActive(true);
        StarterAssetsInputs starterAssets = FindFirstObjectByType<StarterAssetsInputs>();
        starterAssets.SetCursorState(false);
        StartCoroutine(WaitForMusic(4));

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
