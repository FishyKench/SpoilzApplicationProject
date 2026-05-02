using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    PlayerStats playerStats;

    private void Awake()
    {
        currentHealth = maxHealth;
        playerStats = FindAnyObjectByType<PlayerStats>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount;
        Debug.Log(gameObject.name + " health: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if(playerStats != null)
        {
            playerStats.Heal(20f);
        }
        Destroy(gameObject);
    }
}