using UnityEngine;

public class Projectile : MonoBehaviour
{
    //summary
    //the base script used by all projectiles in how they are handled when fired from a tower.
    //summary

    [SerializeField] private int damage = 10;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifetime = 5f;
    private Transform target;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

   //gets the enemy location and fires at that transform
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
    //when the projectile is fired and collides with an enemy it makes the enemy take damage and then deletes itself.
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetComponent<Health>().TakeDamage(damage);

            }
        }
        Destroy(gameObject);
    }
}

