using System.Collections;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGate : EnemyHealth
{
    [SerializeField] GameObject Enemy;
    [SerializeField] Transform spawnPoint;
    [SerializeField] PlayerHealth playerHealth;

    float timeToSpawn = 5f;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (playerHealth)
        {
            PooledObject enemy = EnemyPool.SingleTonItemsPool.GetEnemy("Robot", spawnPoint.position, Quaternion.identity);
            if (enemy == null)
            {
                Debug.LogError("SpawnGate: Enemy not found in pool!");
            }
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
