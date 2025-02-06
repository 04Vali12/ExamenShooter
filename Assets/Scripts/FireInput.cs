using UnityEngine;

public class FireInput : MonoBehaviour
{
    private Gun _gun; 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        
        {
            if (GetWeapon())
            {
                _gun.Shoot();
            }
        
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (GetWeapon())
            {
                _gun.Reload();
            }

        }
    }

    private bool GetWeapon()
    {
        if (_gun == null)
        {
            _gun = gameObject.GetComponent<GetWeapon>()?.Weapon;
        }
        return _gun != null;
    }
}
