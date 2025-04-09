using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : EnemyHealth
{
    [SerializeField] Transform target;
    FirstPersonController player;
    NavMeshAgent navMeshAgent;
    const string PLAYER_STRING = "Player";

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindFirstObjectByType<FirstPersonController>();
    }

    void Update()
    {
        if(!player) return;
        navMeshAgent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PLAYER_STRING)){
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
            enemyHealth.SelfDestruct();
        }
    }
}
