using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] Animator recoilAnimator;
    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;
    const string GUN_RECOIL_ANIMATION = "Recoil";
    float timer = 0;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        HandleShoot();

    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;
        if (timer >= weaponSO.FireRate)
        {
            recoilAnimator.Play(GUN_RECOIL_ANIMATION, 0, 0f);
            currentWeapon.Shoot(weaponSO);
            timer = 0;
        }

        if (!weaponSO.Isautomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(currentWeapon){
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponentInChildren<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;
        
    }

}
