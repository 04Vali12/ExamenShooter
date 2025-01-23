using System;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _RotateSpeed = 5;
    
    [SerializeField]
    private bool _isRotating = true;
    
    public Boolean IsRotating
    {
        get { return _isRotating;}
        set {_isRotating = value;}
    }
    void Update()
    {
       RotateWeapon();
    }
    private void RotateWeapon()
    {
        if (_isRotating)
        {
             gameObject.transform.Rotate(0f,_RotateSpeed * Time.deltaTime, 0f);

        }
    }
}
