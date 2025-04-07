using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 2.0f;
    [SerializeField] int damage = 3;
    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue;
            playerHealth.TakeDamage(damage);

            break;
        }
    }


}
