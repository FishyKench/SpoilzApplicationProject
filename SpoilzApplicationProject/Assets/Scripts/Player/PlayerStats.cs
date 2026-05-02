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

    public void Heal(float amount)
    {
        currentHealth = currentHealth + amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Die()
    {
        GameTimer timer = FindFirstObjectByType<GameTimer>();
        timer.StopTimer();
        DeathScreen deathScreen = FindFirstObjectByType<DeathScreen>();
        deathScreen.ShowDeathScreen(timer.GetTimeFormatted());  
    }
}
