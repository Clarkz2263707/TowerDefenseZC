using UnityEngine;

public class CannonTower : Tower
{
    //Summary
    //Handles the firing operations of the cannon tower
    //Summary

    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private AudioClip CannonShoot;

    protected override void Update()
    {
        base.Update();
    }
    //handles firing operations of the tower by getting enemy location, instantiating cannonball prefab, firing it at the enemy transform, playing a sfx.
    protected override void FireAt(Enemy target)
    {
        if (cannonballPrefab != null && target != null && weaponTransform != null)
        {
            GameObject cannonball = Instantiate(cannonballPrefab, weaponTransform.position, Quaternion.identity);
            Projectile projectile = cannonball.GetComponent<Projectile>();
            SoundManager.instance.PlaySoundFXClip(CannonShoot, transform, 1f);
            if (projectile != null)
            {
                projectile.SetTarget(target.transform);
            }
        }
    }
    //targets the enemy with the highest health within the radius circle that is its firing range.
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
