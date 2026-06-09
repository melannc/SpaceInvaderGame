using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // set spawn positions in Inspector

    public void SpawnEnemies()
    {
        // Clear existing enemies first
        foreach (EnemyHealth enemy in FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None))
        {
            Destroy(enemy.gameObject);
        }

        // Spawn fresh enemies at each spawn point
        foreach (Transform point in spawnPoints)
        {
            Instantiate(enemyPrefab, point.position, Quaternion.identity);
        }
    }
}