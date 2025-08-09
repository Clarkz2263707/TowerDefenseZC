using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public abstract class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 100; 
    public int Cost => cost;

    public float fireCooldown = 1.0f;

    protected float currentFireCooldown = 0.0f;
    protected List<Enemy> enemiesInRange = new List<Enemy>();

    [SerializeField] public Transform weaponTransform;
    [SerializeField] private Tower tower;

    protected virtual void Update()
    {
        currentFireCooldown -= Time.deltaTime;
        Enemy closestEnemy = TargetEnemy;
        if (closestEnemy != null && currentFireCooldown <= 0.0f)
        {
            FireAt(closestEnemy);
            currentFireCooldown = fireCooldown;
        }
        if (tower == null || weaponTransform == null)
            return;

        Enemy target = TargetEnemy;
        if (target != null)
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.y = weaponTransform.position.y;
            weaponTransform.LookAt(targetPosition);
        }
    }

    protected abstract void FireAt(Enemy target);


    protected abstract Enemy TargetEnemy { get; }

    protected void ClearDestroyedEnemies()
    {
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            if (enemiesInRange[i] == null)
            {
                enemiesInRange.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null && enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
    }
}

