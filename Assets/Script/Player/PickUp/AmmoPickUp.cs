using UnityEngine;

public class AmmoPickUp : PickUp
{
    [SerializeField] int ammoRefuse = 100;

    protected override void OnPickUp(ActiveWeapon activeWeapon)
    {
        activeWeapon.AdjustAmmo(ammoRefuse);
    }
}
