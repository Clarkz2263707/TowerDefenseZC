using UnityEngine;
using System.Collections.Generic;

//summary
//handles the overall functions of towers, we made this with Gary.
//summary
[RequireComponent(typeof(SphereCollider))]
public abstract class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 100;
    [SerializeField] public Transform weaponTransform;
    [SerializeField] private Tower tower; 
    public int Cost => cost;
    public float fireCooldown = 1.0f;
    protected float currentFireCooldown = 0.0f;
    protected List<Enemy> enemiesInRange = new List<Enemy>();

    
    
    //gathers the firerate cooldown, closest enemy, weapon transform, and enemy targetting.
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
    //removes enemy from list if they die
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
    //adds enemy to target list if steps into collider range.
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
        }
    }
    //removes enemy from list if they leave collider range
    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null && enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
    }
}

