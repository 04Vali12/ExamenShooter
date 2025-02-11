
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField]
   private string enemyToLook = "Player";
   
   [SerializeField]
   private float speed = 1f;

   private Transform objetive;

   private Health health;

   private void Start()
   {
    objetive = GameObject.FindGameObjectWithTag(enemyToLook).transform;
    health=GetComponent<Health>();

   }
   private void Update()
   {
    FollowObjetive();

   }
   private void FollowObjetive()
   {
    Vector3 direction = (objetive.position-transform.position).normalized;
    transform.position += direction * speed * Time.deltaTime;
   }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
         health.TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
         Destroy(collision.gameObject);

        }
    }
    public void Die()
    {
      Destroy(gameObject);
    }

}
