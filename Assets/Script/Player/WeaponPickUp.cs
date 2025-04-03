using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    ActiveWeapon activeWeapon;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            activeWeapon.SwitchWeapon(weaponSO);
            Destroy(gameObject);
        }
    }

}
