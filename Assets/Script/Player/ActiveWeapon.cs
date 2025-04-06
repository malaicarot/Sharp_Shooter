using UnityEngine;
using StarterAssets;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] Animator recoilAnimator;
    [SerializeField] WeaponSO startingWeaponSO;
    [SerializeField] CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] Camera weaponCamera;

    [SerializeField] Image ZoomVignette;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] float durationZoomIn = 0.1f;
    [SerializeField] float durationZoomOut = 0.1f;

    WeaponSO currentWeaponSO;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Weapon currentWeapon;
    const string GUN_RECOIL_ANIMATION = "Recoil";
    float timer = 0;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;



    float elapsedTime = 0;

    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        currentWeapon = GetComponentInChildren<Weapon>();
        defaultFOV = cinemachineVirtualCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    }

    void Start()
    {
        SwitchWeapon(startingWeaponSO);
    }

    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;

        if (currentAmmo > currentWeaponSO.InitialAmmo) // tránh cộng dồn đạn của 2 loại súng
        {
            currentAmmo = currentWeaponSO.InitialAmmo;
        }

        ammoText.text = currentAmmo.ToString("D2");
    }

    void HandleShoot()
    {
        timer += Time.deltaTime;
        if (!starterAssetsInputs.shoot) return;
        if (timer >= currentWeaponSO.FireRate && currentAmmo > 0)
        {
            recoilAnimator.Play(GUN_RECOIL_ANIMATION, 0, 0f);
            currentWeapon.Shoot(currentWeaponSO);
            if (currentWeaponSO.CanZoom)
            {
                starterAssetsInputs.ZoomInput(false);
            }
            AdjustAmmo(-1);
            timer = 0;
        }

        if (!currentWeaponSO.Isautomatic)
        {
            starterAssetsInputs.ShootInput(false);
        }
    }

    void HandleZoom()
    {
        if (!currentWeaponSO.CanZoom) return;
        if (starterAssetsInputs.zoom)
        {
            if (cinemachineVirtualCamera.m_Lens.FieldOfView == currentWeaponSO.ZoomAmout) return;
            weaponCamera.fieldOfView = currentWeaponSO.ZoomAmout;
            ProcessZoom(defaultFOV, currentWeaponSO.ZoomAmout, durationZoomIn);
            ZoomVignette.gameObject.SetActive(starterAssetsInputs.zoom);
            firstPersonController.ChangeRotationSpeed(currentWeaponSO.RotationSpeed);
        }
        else
        {
            if (cinemachineVirtualCamera.m_Lens.FieldOfView == defaultFOV)
            {
                elapsedTime = 0;
                return;
            }
            weaponCamera.fieldOfView = defaultFOV;
            ProcessZoom(currentWeaponSO.ZoomAmout, defaultFOV, durationZoomOut);
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
        this.currentWeaponSO = weaponSO;
        AdjustAmmo(weaponSO.InitialAmmo);
    }
}
