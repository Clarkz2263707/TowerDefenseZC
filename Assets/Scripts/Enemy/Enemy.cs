using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Summary
    //Establishes an animator, the damage, dropped money (which can be editted in inspector per enemy type), and audio that has to do with the enemy. More comments below.
    //Summary

    private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform EndPoint;
    [SerializeField] private string animatorParam_Iswalking;
    [SerializeField] private int damage;
    [SerializeField] private int moneyDropped = 10;
    [SerializeField] private AudioClip EnemyDeath;

    private Health health;

    public event System.Action<Enemy> OnEnemyDeath;
    //grabs components on spawning
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }
    //establishes enemy animations if they are alive
    void Start()
    {
        animator.SetBool(animatorParam_Iswalking, true);
        if (health != null)
        {
            health.onHealthChanged += CheckEnemyDeath;
        }
    }

    //sets the endpoint when initialized/spawned
    public void Initialized(Transform inputEndPoint)
    {   
        EndPoint = inputEndPoint;
        agent.SetDestination(inputEndPoint.position);
    }

    //grabs the distance the agent has to travel to the endpoint and when it reaches the end it calls the reachedend method.
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

    //when the enemy reaches the end it destroys the enemy and deals damage, also ceases animation.
    private void ReachedEnd()
    {
        animator.SetBool(animatorParam_Iswalking, false);
        GameManager.Instance.playerHealth.TakeDamage(damage);
        Destroy(gameObject);
    }
    //checks enemy health and if health is 0 they die.
    void CheckEnemyDeath(int currentHealth, int maxHealth)
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //handles death, gives money, destroys game object and plays death audio.
    public void Die()
    {
        MoneyManager.Instance?.AddMoney(moneyDropped);
        OnEnemyDeath?.Invoke(this);
        Destroy(gameObject);
        SoundManager.instance.PlaySoundFXClip(EnemyDeath, transform, .1f);
    }
}
