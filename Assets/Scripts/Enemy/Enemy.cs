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

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        agent.SetDestination(EndPoint.position);
        animator.SetBool(animatorParam_Iswalking, true);
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
}
