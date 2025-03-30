using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    [SerializeField] int dame = 1;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] Animator recoilAnimator;
    StarterAssetsInputs starterAssetsInputs;


    const string GUN_RECOIL_ANIMATION = "Recoil";



    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }


    void Update()
    {
        HandleShoot();

    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;
        recoilAnimator.Play(GUN_RECOIL_ANIMATION, 0, 0f);
        muzzleFlash.Play();
        starterAssetsInputs.ShootInput(false);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Robot robot = hit.collider.GetComponent<Robot>();
            robot?.TakeDamage(dame);

        }
    }

}
