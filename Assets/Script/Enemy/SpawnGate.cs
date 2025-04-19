using System.Collections;
using UnityEngine;

public class SpawnGate : EnemyHealth
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform spawnPoint;
    [SerializeField] PlayerHealth playerHealth;

    const string ROBOT_NAME = "Robot";

    float timeToSpawn = 5f;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (playerHealth)
        {
            RobotMarkPool enemy = EnemyPool.SingleTonItemsPool.GetEnemy(ROBOT_NAME, spawnPoint.position, Quaternion.identity);
            if (enemy == null)
            {
                Debug.LogError("SpawnGate: Enemy not found in pool!");
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
