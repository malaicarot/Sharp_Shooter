using System.Collections;
using UnityEngine;

public class Turret : EnemyHealth
{
    [SerializeField] GameObject bulletTurret;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform targetLookAt;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Transform turretProjectile;
    [SerializeField] int damage = 2;

    float fireRate = 2f;
    void Start()
    {
        StartCoroutine(TurretShooting());
    }

    void Update()
    {
        turretHead.gameObject.transform.LookAt(targetLookAt);
    }

    IEnumerator TurretShooting(){

        while (playerHealth)
        {
            yield return new WaitForSeconds(fireRate);

            Projectile projectile = Instantiate(bulletTurret, turretProjectile.position, turretHead.rotation).GetComponent<Projectile>();
            projectile.Init(damage);
        }

    }
}
