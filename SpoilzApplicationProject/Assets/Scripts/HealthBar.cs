using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerStats playerStats;

    private void Start()
    {
        healthSlider.maxValue = playerStats.maxHealth;
        healthSlider.value = playerStats.currentHealth;
    }

    private void Update()
    {
        healthSlider.value = playerStats.currentHealth;
    }
}