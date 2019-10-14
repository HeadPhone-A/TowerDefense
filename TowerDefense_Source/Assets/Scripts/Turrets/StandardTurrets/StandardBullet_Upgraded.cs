public class StandardBullet_Upgraded : StandardBullet
{
    private StandardTurret_Upgraded turret_Upgrade;

    protected override void Start()
    {
        turret_Upgrade = transform.parent.GetComponent<StandardTurret_Upgraded>();
        target = turret_Upgrade.target;
        damage = turret_Upgrade.damage;
        speed = turret_Upgrade.bulletSpeed;
        bulletImpactEffect = turret_Upgrade.bulletImpactEffect;
    }
}
