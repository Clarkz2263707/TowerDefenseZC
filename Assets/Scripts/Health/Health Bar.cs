using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image bar;

    void Start()
    {
        if (health != null)
        {
            health.onHealthChanged += UpdateHealthbar;
        }
    }

    void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        bar.fillAmount = (float)currentHealth / maxHealth;
    }
}
