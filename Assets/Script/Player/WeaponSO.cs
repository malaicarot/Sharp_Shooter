using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject weaponPrefab;
    public int Damage = 1;
    public float FireRate = 0.5f;
    public ParticleSystem HitFlash;
    public bool Isautomatic = false;
    public bool CanZoom = false;
    public float ZoomAmout = 10f;
    public float RotationSpeed = 0.3f;
}
