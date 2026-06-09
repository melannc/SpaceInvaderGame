using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyBullet = false; // toggle this on enemy's bullet prefab

    private bool hasHit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        // Player bullet hits enemy
        if (!isEnemyBullet && other.CompareTag("Enemy"))
        {
            hasHit = true;
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        // Enemy bullet hits player
        if (isEnemyBullet && other.CompareTag("Player"))
        {
            hasHit = true;
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}