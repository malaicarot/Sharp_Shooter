using UnityEngine;
using StarterAssets;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    [SerializeField] int dame = 1;
    StarterAssetsInputs starterAssetsInputs;


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
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Robot robot = hit.collider.GetComponent<Robot>();
            robot?.TakeDamage(dame);

        }
        starterAssetsInputs.ShootInput(false);
    }

}
