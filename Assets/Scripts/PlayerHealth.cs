using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    private bool isDead = false; // prevents multiple triggers on death

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void resetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // ignore damage if already dead

        currentHealth -= damage;
        FindFirstObjectByType<UIManagerScript>().DecreaseLives();

        if (currentHealth <= 0)
        {
            isDead = true;
            currentHealth = maxHealth;
            isDead = false; // ready for next life
        }
    }
}