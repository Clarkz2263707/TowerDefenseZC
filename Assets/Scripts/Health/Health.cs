using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public event Action<int, int> onHealthChanged;

    [SerializeField] private int maxHealth = 20;
    private int currentHealth;

    [SerializeField] private string gameOver = "GameOverMenu"; 

    public int CurrentHealth => currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public bool isDead()
    {
        return currentHealth > 0;
    }

    public void TakeDamage(int damageAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth = Mathf.Max(currentHealth - damageAmount, 0);
            onHealthChanged?.Invoke(currentHealth, maxHealth);

            if (currentHealth == 0)
            {
                SceneManager.LoadScene(gameOver);
            }
        }
        Debug.Log($"Current Health: {currentHealth}");
    }
}
