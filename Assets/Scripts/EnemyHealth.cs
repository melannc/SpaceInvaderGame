using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage: " + damage);
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        AudioManager.Instance.PlayEnemyDestroy();
        FindFirstObjectByType<UIManagerScript>().AddScore(100);
        Destroy(gameObject); // destroy first

        // Wait a frame before checking so destroy completes
        FindFirstObjectByType<UIManagerScript>().StartCoroutine(
            FindFirstObjectByType<UIManagerScript>().WaitAndCheckWin()
        );
    }
}