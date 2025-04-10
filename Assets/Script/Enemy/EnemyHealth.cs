using JetBrains.Annotations;
using UnityEngine;

public abstract class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] ParticleSystem ExplodeParticleSystem;
    [SerializeField] Transform exactTransformRobot;

    int currentHealth;


    void Awake()
    {
        currentHealth = health;
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
        Destroy(gameObject);
    }
}
