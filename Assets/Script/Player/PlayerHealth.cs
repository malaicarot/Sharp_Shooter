using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;


    int currentHealth;


    void Start()
    {
        currentHealth = health;
    }


    public void TakeDamage(int dame)
    {
        currentHealth -= dame;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
