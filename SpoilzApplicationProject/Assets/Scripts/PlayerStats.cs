using System.Linq.Expressions;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;

    public float currentHealth;
    


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth = currentHealth - amount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        FindFirstObjectByType<DeathScreen>().ShowDeathScreen();
    }
}
