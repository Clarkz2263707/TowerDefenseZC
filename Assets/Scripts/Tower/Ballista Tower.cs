using UnityEngine;

public class BallistaTower : Tower
{
    //summary
    //handles the firing operations of the ballista tower
    //summary
    [SerializeField] private Projectile arrowPrefab;
    [SerializeField] private AudioClip BallistaShoot;
    

    protected override void Update()
    {
        base.Update();
        
    }
    //Shoots ballista prefab projectile at the set target at the time and plays a sound when it does so.
    protected override void FireAt(Enemy target)
    {
        if (arrowPrefab != null)
        {
            GameObject arrowInstance = Instantiate(arrowPrefab.gameObject, weaponTransform.position, Quaternion.identity);
            arrowInstance.GetComponent<Projectile>().SetTarget(target.transform);
            SoundManager.instance.PlaySoundFXClip(BallistaShoot, transform, 1f);
        }
    }
    //when an enemy dies it gets the next enemy in its radius.
    protected override Enemy TargetEnemy
    {
        get
        {
            ClearDestroyedEnemies();
            return enemiesInRange.Count > 0 ? enemiesInRange[0] : null;
        }
    }
}
