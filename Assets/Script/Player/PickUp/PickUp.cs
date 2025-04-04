using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    [SerializeField] float rotation = 100f;
    [SerializeField] string playerString = "Player";
    ActiveWeapon activeWeapon;


    void Update()
    {
        transform.Rotate(0f, rotation * Time.deltaTime, 0f, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickUp(activeWeapon);
            Destroy(gameObject);
        }
    }

    protected virtual void OnPickUp(ActiveWeapon activeWeapon)
    {

    }
}
