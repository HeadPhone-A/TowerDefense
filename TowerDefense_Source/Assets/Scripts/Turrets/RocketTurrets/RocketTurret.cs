using UnityEngine;

public class RocketTurret : TurretBase
{
    public Transform[] firePoints;
    public float fireRate = 0.3f;

    public float bulletSpeed = 50f;
    public GameObject bulletPrefab = null;
    public GameObject bulletImpactEffect = null;

    public float explosionRadius = 5f;
    public LayerMask explosionTargetLayerMask = 0;

    public float currentFireRate;
    public int firePointCount;

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

    protected virtual void ShootBullet()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoints[firePointCount].position, firePoints[firePointCount].rotation);
        bulletGameObject.transform.parent = gameObject.transform;
    }
}
