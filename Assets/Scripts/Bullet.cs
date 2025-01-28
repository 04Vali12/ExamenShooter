using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _Rigidbody;
    [SerializeField]
    private float _bulletSpeed;

    private void OnEnable()
    {
        if (_Rigidbody == null)
        {
            _Rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        _Rigidbody.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
    }
}
