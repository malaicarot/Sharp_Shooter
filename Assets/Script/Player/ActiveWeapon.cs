using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] Animator recoilAnimator;
    [SerializeField] WeaponSO weaponSO;
    StarterAssetsInputs starterAssetsInputs;
    Weapon weapon;
    const string GUN_RECOIL_ANIMATION = "Recoil";
    float timer = 0;



    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        weapon = GetComponentInChildren<Weapon>();
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
            weapon.Shoot(weaponSO);
            timer = 0;
        }
        starterAssetsInputs.ShootInput(false);


    }
}
