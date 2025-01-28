using UnityEngine;

public class FireInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        gameObject.GetComponent<GetWeapon>().Weapon?.Shoot();
        }
    }
}
