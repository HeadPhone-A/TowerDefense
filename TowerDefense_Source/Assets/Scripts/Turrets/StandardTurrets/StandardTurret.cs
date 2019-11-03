using UnityEngine;

public class StandardTurret : TurretBase
{
    public Transform[] firePoints;
    public float fireRate = 0.3f;

    public float bulletSpeed = 50f;
    public GameObject bulletPrefab = null;
    public GameObject bulletImpactEffect = null;

    protected float currentFireRate;
    protected int firePointCount;

    protected override void Update()
    {
        base.Update();
        if (target != null)
        {
            currentFireRate -= Time.deltaTime;
            if (currentFireRate <= 0)
            {
                ShootBullet();
                currentFireRate = fireRate;
                firePointCount++;
                if (firePointCount == firePoints.Length)
                {
                    firePointCount = 0;
                }
            }
        }
    }

    protected void ShootBullet()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoints[firePointCount].position, firePoints[firePointCount].rotation);
        bulletGameObject.transform.parent = gameObject.transform;
    }
}
