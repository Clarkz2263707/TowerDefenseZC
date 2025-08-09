using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField] private GameObject cannonballPrefab;

    protected override void Update()
    {
        base.Update();
    }

    protected override void FireAt(Enemy target)
    {
        if (cannonballPrefab != null && target != null && weaponTransform != null)
        {
            GameObject cannonball = Instantiate(cannonballPrefab, weaponTransform.position, Quaternion.identity);
            Projectile projectile = cannonball.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.SetTarget(target.transform);
            }
        }
    }

    protected override Enemy TargetEnemy
    {
        get
        {
            ClearDestroyedEnemies();
            Enemy highestHealthEnemy = null;
            int highestHealth = int.MinValue;
            foreach (var enemy in enemiesInRange)
            {
                if (enemy == null) continue;
                Health health = enemy.GetComponent<Health>();
                if (health != null && health.CurrentHealth > highestHealth)
                {
                    highestHealth = health.CurrentHealth;
                    highestHealthEnemy = enemy;
                }
            }
            return highestHealthEnemy;
        }
    }
}
