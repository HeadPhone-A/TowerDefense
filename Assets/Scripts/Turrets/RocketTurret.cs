using UnityEngine;

public class RocketTurret : TurretBase
{
    public float fireRate = 0.3f;

    public float bulletSpeed = 50f;
    public GameObject bulletPrefab = null;
    public GameObject bulletImpactEffect = null;

    public float explosionRadius = 5f;
    public LayerMask explosionTargetLayerMask = 0;

    private float currentFireRate;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
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

    private void ShootBullet()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletGameObject.transform.parent = gameObject.transform;
    }
}
