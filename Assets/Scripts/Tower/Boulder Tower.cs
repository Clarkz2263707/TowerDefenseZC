using UnityEngine;

public class BoulderTower : Tower
{
    [SerializeField] private Boulder boulderPrefab;
    [SerializeField] private Transform firePoint;

    protected override void FireAt(Enemy target)
    {
        if (boulderPrefab != null && firePoint != null && target != null)
        {
            Boulder boulder = Instantiate(boulderPrefab, firePoint.position, Quaternion.identity);
            boulder.SetTarget(target.transform);
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
