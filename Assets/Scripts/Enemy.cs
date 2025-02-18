
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField]
   private string enemyToLook = "Player";
   
   [SerializeField]
   private float speed = 1f;

   private Transform objetive;

   private Health health;

    private Animator animator;

    [SerializeField]
    private int damageAmount = 1;


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
    Vector3 direction = (objetive.position - transform.position).normalized;
        if (direction.magnitude > 0.1f) // Check if the enemy is moving
        {
            transform.position += direction * speed * Time.deltaTime;
            //animator.SetBool("isWalking", true); // Trigger walking animation
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
        else
        {
            //animator.SetBool("isWalking", false); // Stop walking animation
        }
   }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
         health.TakeDamage(collision.gameObject.GetComponent<Bullet>().Damage);
         Destroy(collision.gameObject);

        }
         if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
    public void Die()
    {
      Destroy(gameObject);
    }
     
}
