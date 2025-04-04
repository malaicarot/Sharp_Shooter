using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask interactLayerMask;
    
    public void Shoot(WeaponSO weaponSO)
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, interactLayerMask, QueryTriggerInteraction.Ignore))
        {
            Robot robot = hit.collider.GetComponent<Robot>();
            robot?.TakeDamage(weaponSO.Damage);
            Instantiate(weaponSO.HitFlash, hit.point, Quaternion.identity);
        }
    }

}
