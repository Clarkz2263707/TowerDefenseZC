using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Text healthText;
    void Start()
    {
        if (health != null)
        {
            health.onHealthChanged += UpdateHealthText;
        }
    }

   
    void UpdateHealthText(int currentHealth, int maxHealth)
    {
        
    }
}
