using TMPro;
using UnityEngine;
//summary
//Handles the cash within the levels.
//summary
public class MoneyManager : MonoBehaviour
{
    //establishes starting money
    public static MoneyManager Instance { get; private set; }

    [SerializeField] private int startingMoney = 200;
    private int currentMoney;
    public TextMeshProUGUI text;

    void Awake()
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
    }

    void Start()
    {
        currentMoney = startingMoney;
        UpdateMoneyUI();
    }
    //add money method for when an enemy is killed
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }
    //spend money method used to build towers in tower script
    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            return true;
        }
        return false;
    }
    //gets current money to be displayed
    public int GetMoney()
    {
        return currentMoney;
    }
    //displays current money.
    private void UpdateMoneyUI()
    {
        if (text != null)
        {
            text.text = $"${currentMoney}";
        }
    }
}
