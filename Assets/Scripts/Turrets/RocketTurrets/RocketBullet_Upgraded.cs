using UnityEngine;

public class RocketBullet_Upgraded : RocketBullet
{
    private RocketTurret_Upgraded turret_Upgrade;

    protected override void Start()
    {
        turret_Upgrade = transform.parent.GetComponent<RocketTurret_Upgraded>();
        target = turret_Upgrade.target;
        damage = turret_Upgrade.damage;
        speed = turret_Upgrade.bulletSpeed;
        bulletImpactEffect = turret_Upgrade.bulletImpactEffect;
        explosionTargetLayerMask = turret_Upgrade.explosionTargetLayerMask;
        explosionRadius = turret_Upgrade.explosionRadius;
    }
}
