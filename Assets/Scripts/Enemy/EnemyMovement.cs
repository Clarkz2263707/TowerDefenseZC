using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
   private NavMeshAgent agent;
    private Animator animator;
    [SerializeField] private Transform EndPoint;
    [SerializeField] private string animatorParam_Iswalking;

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
        if (agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                animator.SetBool(animatorParam_Iswalking, false);
            }
        }
    }
}
