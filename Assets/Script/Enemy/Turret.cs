using System.Collections;
using UnityEngine;

public class Turret : EnemyHealth
{
    [SerializeField] GameObject bulletTurret;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform targetLookAt;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Transform turretProjectile;


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
            Instantiate(bulletTurret, turretProjectile.position, turretHead.rotation);
            yield return new WaitForSeconds(fireRate);
        }

    }
}
