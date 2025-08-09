using UnityEngine;

public class CatapultTower : Tower
{
    [SerializeField] private CatapultProjectile catapultProjectilePrefab;

    protected override void Update()
    {
        base.Update();
    }

    protected override void FireAt(Enemy target)
    {
        if (catapultProjectilePrefab != null && target != null && weaponTransform != null)
        {
            CatapultProjectile projectile = Instantiate(catapultProjectilePrefab, weaponTransform.position, Quaternion.identity);
            projectile.SetTarget(target.transform);
        }
    }

    protected override Enemy TargetEnemy
    {
        get
        {
            ClearDestroyedEnemies();
            return enemiesInRange.Count > 0 ? enemiesInRange[0] : null;
        }
    }
}
