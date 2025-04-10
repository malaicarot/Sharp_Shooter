using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;
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

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactLayerMask, QueryTriggerInteraction.Ignore))
        {
            Robot robot = hit.collider.GetComponent<Robot>();
            SpawnGate spawnGate = hit.collider.GetComponent<SpawnGate>();
            robot?.TakeDamage(weaponSO.Damage);
            spawnGate?.TakeDamage(weaponSO.Damage);
            Instantiate(weaponSO.HitFlash, hit.point, Quaternion.identity);
        }
    }

}
