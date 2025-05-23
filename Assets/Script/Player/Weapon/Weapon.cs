using UnityEngine;
using Cinemachine;


public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactLayerMask;
    CinemachineImpulseSource cinemachineImpulseSource;


    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }


    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();
        cinemachineImpulseSource.GenerateImpulse();
        SoundSingleton.soundInstance.PlaySoundGun(weaponSO.indexSFX);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactLayerMask, QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.HitFlash, hit.point, Quaternion.identity);
            EnemyHealth enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);
        }
    }

}
