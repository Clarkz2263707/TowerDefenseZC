using UnityEngine;

public class GameManager : MonoBehaviour
{
    //gets the player health and establisehs it so that the game can use it when enemies touch the crystal.
    public static GameManager Instance { get; private set; }
    public Health playerHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        playerHealth = GetComponent<Health>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
