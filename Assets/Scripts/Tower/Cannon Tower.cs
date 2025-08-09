using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField] private GameObject cannonballPrefab;
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void FireAt(Enemy target)
    {
        //add cannon specific firing logic here
    }

    protected override Enemy TargetEnemy =>
        //add canon specific logic to get the target enemy here
        null;
}
