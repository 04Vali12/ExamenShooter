using UnityEngine;

public class PLayer : MonoBehaviour
{
    private Health health;
    private UIController uiController;
    private bool isPlaying = true;

    private void Start()
    {
        health=GetComponent<Health>();
        uiController = GetComponent<UIController>();
    }
    private void OllisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isPlaying)
        {
            health.TakeDamage(1);
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            transform.position += pushDirection * 0.5f;
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            uiController.ShowGameWinUI(true);
        }
    }
    public void Die()
    {
       uiController.ShowGameOverUI(true);
    }
    public void Win()
    {
        uiController.ShowWinUI(true);
    }
}
