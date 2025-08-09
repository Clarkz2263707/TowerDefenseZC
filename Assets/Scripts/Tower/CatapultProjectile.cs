using UnityEngine;

public class CatapultProjectile : MonoBehaviour
{
    [SerializeField] private int damage = 20;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float explosionRadius = 3f;
    private Transform target;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.forward = direction;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform inputTarget)
    {
        target = inputTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null && other.transform == target)
        {
            
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (var hit in hitColliders)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Health health = enemy.GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
