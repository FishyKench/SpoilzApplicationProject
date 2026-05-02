using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    public AudioSource audioSource;

    public AudioClip deathSound;

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
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.5f);
        if (playerStats != null)
        {
            playerStats.Heal(20f);
        }
        Destroy(gameObject);
    }
}