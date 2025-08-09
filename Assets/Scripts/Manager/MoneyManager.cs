using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
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

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
    }

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

    public int GetMoney()
    {
        return currentMoney;
    }

    private void UpdateMoneyUI()
    {
        if (text != null)
        {
            text.text = $"${currentMoney}";
        }
    }
}
