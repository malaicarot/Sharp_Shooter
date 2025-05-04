using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
public class Robot : EnemyHealth
{
    FirstPersonController player;
    NavMeshAgent navMeshAgent;
    const string PLAYER_STRING = "Player";

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindFirstObjectByType<FirstPersonController>();
    }

    void Update()
    {
        if (!player) return;
        navMeshAgent.SetDestination(player.transform.position);
        
    }

    IEnumerator RobotWorkSound()
    {
        yield return new WaitForSeconds(1);
        SoundSingleton.soundInstance.PlaySFX(4);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            SelfDestruct();
        }
    }
}
