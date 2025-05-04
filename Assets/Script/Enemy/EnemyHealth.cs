using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] ParticleSystem ExplodeParticleSystem;
    [SerializeField] Transform exactTransformRobot;
    // GameManagers gameManagers;

    int currentHealth;

    void Awake()
    {
        currentHealth = health;
    }

    public int Health
    {
        get { return currentHealth; }
    }


    public void TakeDamage(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            SelfDestruct();
            if (this.gameObject.CompareTag("Boss"))
            {
                GameManagers.Instance.Winner();
            }
        }
    }

    public void SelfDestruct()
    {
        Instantiate(ExplodeParticleSystem, exactTransformRobot.position, Quaternion.identity);
        ExplodeParticleSystem.Play();
        if (!this.gameObject.CompareTag("Boss"))
        {
            GameManagers.Instance.AdjustEnemy(-1);
            SoundSingleton.soundInstance.PlaySFX(2);
        }else{
            SoundSingleton.soundInstance.PlaySFX(3);
        }

        //Nếu là opol object thì return
        RobotMarkPool robot = gameObject.GetComponent<RobotMarkPool>();
        robot?.RobotRelease();
        if (robot == null)
        {
            Destroy(gameObject);
        }
    }
}
