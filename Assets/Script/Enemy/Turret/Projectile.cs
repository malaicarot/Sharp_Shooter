using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem projectileParticleSystem;
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float timeExist = 2f;


    Rigidbody bulletRigidbody;
    PlayerHealth target;
    int damage;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        target = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(TimeExists());
    }

    void Update()
    {
        if (!target) return;
        ProccessMove();
    }

    void ProccessMove()
    {
        bulletRigidbody.linearVelocity = (target.transform.position - transform.position) * bulletSpeed;
    }
    IEnumerator TimeExists()
    {
        yield return new WaitForSeconds(timeExist);
        Destroy(this.gameObject);
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Turret"))
        {
            Destroy(this.gameObject);
            if (collision.gameObject.CompareTag("Player"))
            {
                target.TakeDamage(damage);
            }
            Instantiate(projectileParticleSystem, transform.position, Quaternion.identity);
        }
    }
}
