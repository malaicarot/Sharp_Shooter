using UnityEngine;
using StarterAssets;
using Cinemachine;
using UnityEngine.UI;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] Animator recoilAnimator;
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] Image ZoomVignette;
    [SerializeField] float durationZoomIn = 0.1f;
    [SerializeField] float durationZoomOut = 0.1f;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;
    const string GUN_RECOIL_ANIMATION = "Recoil";
    float timer = 0;
    float defaultFOV;
    float defaultRotationSpeed;



    float elapsedTime = 0;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        currentWeapon = GetComponentInChildren<Weapon>();
        defaultFOV = cinemachineVirtualCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    void HandleShoot()
    {
        timer += Time.deltaTime;
        if (!starterAssetsInputs.shoot) return;
        if (timer >= weaponSO.FireRate)
        {
            recoilAnimator.Play(GUN_RECOIL_ANIMATION, 0, 0f);
            currentWeapon.Shoot(weaponSO);
            if (weaponSO.CanZoom)
            {
                starterAssetsInputs.ZoomInput(false);
                // ProcessZoom(weaponSO.ZoomAmout, defaultFOV, durationZoomOut);
            }
            timer = 0;
        }

        if (!weaponSO.Isautomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }

    }

    void HandleZoom()
    {
        if (!weaponSO.CanZoom) return;
        if (starterAssetsInputs.zoom)
        {
            if (cinemachineVirtualCamera.m_Lens.FieldOfView == weaponSO.ZoomAmout) return;
            ProcessZoom(defaultFOV, weaponSO.ZoomAmout, durationZoomIn);
            ZoomVignette.gameObject.SetActive(starterAssetsInputs.zoom);
            firstPersonController.ChangeRotationSpeed(weaponSO.RotationSpeed);
        }
        else
        {
            if (cinemachineVirtualCamera.m_Lens.FieldOfView == defaultFOV)
            {
                elapsedTime = 0;
                return;
            }
            ProcessZoom(weaponSO.ZoomAmout, defaultFOV, durationZoomOut);
            ZoomVignette.gameObject.SetActive(starterAssetsInputs.zoom);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);

        }

    }

    void ProcessZoom(float a, float b, float t)
    {
        elapsedTime += Time.deltaTime;
        float time = elapsedTime / t;
        cinemachineVirtualCamera.m_Lens.FieldOfView = Mathf.Lerp(a, b, time);
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }
        Weapon newWeapon = Instantiate(weaponSO.weaponPrefab, transform).GetComponentInChildren<Weapon>();
        currentWeapon = newWeapon;
        this.weaponSO = weaponSO;

    }
}
