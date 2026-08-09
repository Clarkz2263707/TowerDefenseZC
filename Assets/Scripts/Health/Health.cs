using UnityEngine;
using System;
using UnityEngine.SceneManagement;
//summary
//handles the overall health which is used in game manager and enemy scripts.
//summary
public class Health : MonoBehaviour
{
    //establishes parameters used for health
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
    //when you take damage it displays in console and when you reach 0 it loads you to game over screen.
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
