using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float _RotateSpeed = 5;
    
    void Update()
    {
        gameObject.transform.Rotate(0f,_RotateSpeed * Time.deltaTime, 0f);
    }
}
