using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform EndPoint;
    [SerializeField] private string animatorParam_Iswalking;
    [SerializeField] private int damage;
    [SerializeField] private int moneyDropped = 10; 

    private Health health;

    public event System.Action<Enemy> OnEnemyDeath;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }
    void Start()
    {
        animator.SetBool(animatorParam_Iswalking, true);
        if (health != null)
        {
            health.onHealthChanged += CheckEnemyDeath;
        }
    }

    public void Initialized(Transform inputEndPoint)
    {   
        EndPoint = inputEndPoint;
        agent.SetDestination(inputEndPoint.position);
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                ReachedEnd();
            }
        }
    }

    private void ReachedEnd()
    {
        animator.SetBool(animatorParam_Iswalking, false);
        GameManager.Instance.playerHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
    void CheckEnemyDeath(int currentHealth, int maxHealth)
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        MoneyManager.Instance?.AddMoney(moneyDropped);
        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject);
    }
}
