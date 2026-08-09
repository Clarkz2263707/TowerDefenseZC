using UnityEngine;

public class CatapultTower : Tower
{
    //summary
    //handles the firing operations of the catapult tower
    //summary

    [SerializeField] private CatapultProjectile catapultProjectilePrefab;
    [SerializeField] private AudioClip CatapultShoot;

    protected override void Update()
    {
        base.Update();
    }

    //handles the firing operations of the catapult tower. plays a sound when the projectile is actually fired.
    protected override void FireAt(Enemy target)
    {
        if (catapultProjectilePrefab != null && target != null && weaponTransform != null)
        {
            CatapultProjectile projectile = Instantiate(catapultProjectilePrefab, weaponTransform.position, Quaternion.identity);
            projectile.SetTarget(target.transform);
            SoundManager.instance.PlaySoundFXClip(CatapultShoot, transform, 1f);

        }
    }
    //handles enemy targetting
    protected override Enemy TargetEnemy
    {
        get
        {
            ClearDestroyedEnemies();
            return enemiesInRange.Count > 0 ? enemiesInRange[0] : null;
        }
    }
}
