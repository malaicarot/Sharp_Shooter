using JetBrains.Annotations;
using UnityEngine;

public abstract class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] ParticleSystem ExplodeParticleSystem;
    [SerializeField] Transform exactTransformRobot;
    GameManagers gameManagers;

    int currentHealth;


    void Awake()
    {
        currentHealth = health;
        gameManagers = FindFirstObjectByType<GameManagers>();
        gameManagers.AdjustEnemy(1);
    }

    public int Health{
        get{return currentHealth;}
    }


    public void TakeDamage(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(ExplodeParticleSystem, exactTransformRobot.position, Quaternion.identity);
        ExplodeParticleSystem.Play();
        gameManagers.AdjustEnemy(-1);
        Destroy(gameObject);
    }
}
