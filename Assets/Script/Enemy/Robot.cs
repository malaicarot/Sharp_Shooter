using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : EnemyHealth
{
    [SerializeField] Transform target;
    FirstPersonController player;
    NavMeshAgent navMeshAgent;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindFirstObjectByType<FirstPersonController>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);

    }
}
