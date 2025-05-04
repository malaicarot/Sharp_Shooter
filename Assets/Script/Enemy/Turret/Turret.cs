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
        if (!this.gameObject.CompareTag("Boss"))
        {
            GameManagers.Instance.AdjustEnemy(1);
        }

        StartCoroutine(TurretShooting());
    }

    void Update()
    {
        if (!this.gameObject.CompareTag("Boss"))
        {
            turretHead.gameObject.transform.LookAt(targetLookAt);
        }
    }

    IEnumerator TurretShooting()
    {
        while (playerHealth)
        {
            if(this.gameObject.CompareTag("Boss")){
                SoundSingleton.soundInstance.PlaySFX(1);
            }else{
                SoundSingleton.soundInstance.PlaySFX(0);
            }
            yield return new WaitForSeconds(fireRate);
            Projectile projectile = Instantiate(bulletTurret, turretProjectile.position, turretHead.rotation).GetComponent<Projectile>();
            projectile.Init(damage);
        }

    }
}
