using UnityEngine;

public class BallistaTower : Tower
{
    [SerializeField] private Projectile arrowPrefab;
   

    protected override void Update()
    {
        base.Update();
        
    }

    protected override void FireAt(Enemy target)
    {
        if (arrowPrefab != null)
        {
            GameObject arrowInstance = Instantiate(arrowPrefab.gameObject, transform.position, Quaternion.identity);
            arrowInstance.GetComponent<Projectile>().SetTarget(target.transform);
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
