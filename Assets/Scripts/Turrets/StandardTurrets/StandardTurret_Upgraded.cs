using UnityEngine;

public class StandardTurret_Upgraded : StandardTurret
{
    public Transform firePoint;

    protected override void Update()
    {
        UpdateTurretRotate();
        if (target != null)
        {
            currentFireRate -= Time.deltaTime;
            if (currentFireRate <= 0)
            {
                ShootBullet();
                currentFireRate = fireRate;
            }
        }
    }

    protected override void ShootBullet()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletGameObject.transform.parent = gameObject.transform;
    }
}
