using System.Collections;
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
            Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
