using UnityEngine;
using UnityEngine.UI;

//summary
//handles the healthbar UI element
//summary
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image bar;
    //calls upon the update healthbar function when healthbar is changed.
    void Start()
    {
        if (health != null)
        {
            health.onHealthChanged += UpdateHealthbar;
        }
    }
    //updates the healthbar when health changes
    void UpdateHealthbar(int currentHealth, int maxHealth)
    {
        bar.fillAmount = (float)currentHealth / maxHealth;
    }
}
