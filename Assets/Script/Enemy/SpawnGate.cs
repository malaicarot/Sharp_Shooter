using System.Collections;
using UnityEngine;

public class SpawnGate : EnemyHealth
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] PlayerHealth playerHealth;

    const string ROBOT_NAME = "Robot";

    float timeToSpawn = 5f;
    float timer = 0;


    void Start()
    {
        GameManagers.Instance.AdjustEnemy(1);
    }
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn && playerHealth)
        {

            RobotMarkPool enemy = EnemyPool.SingleTonItemsPool.GetEnemy(ROBOT_NAME, spawnPoint.position, Quaternion.identity);
            GameManagers.Instance.AdjustEnemy(1);

            if (enemy == null)
            {
                Debug.LogError("SpawnGate: Enemy not found in pool!");
            }
            timer = 0;
        }
    }
}
