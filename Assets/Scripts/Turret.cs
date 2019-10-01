using UnityEngine;

public enum TurretType
{
    TURRET_TYPE_STANDARD,
    TURRET_TYPE_CANNON,
    TURRET_TYPE_LASER
}

public class Turret : MonoBehaviour
{
    public TurretType turretType = TurretType.TURRET_TYPE_STANDARD;

    public LayerMask targetLayerMask = 0;
    public Transform partToRotate = null;
    public Transform firePoint = null;

    public float damage = 100f;
    public float radius = 10f;
    public float turnSpeed = 10f;
    public float fireRate = 0.5f;

    public GameObject bulletPrefab = null;
    public float bulletSpeed = 50f;
    public GameObject bulletImpactEffect = null;

    public LayerMask explosionLayerMask = 0;
    public float explosionRadius = 5f;
    public GameObject explosionImpactEffect = null;

    public LineRenderer laserLineRenderer = null;
    public ParticleSystem laserImpactEffect = null;

    public float laserSlowPercent = 0.5f;

    public bool fireRadiusGizmos = true;
    public Color fireRadiusGizmosColor = Color.red;

    public Transform target;
    private Light laserImpactLight = null;
    private float currentFireRate;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        laserImpactLight = laserImpactEffect.GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (target == null)
        {
            partToRotate.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
            switch (turretType)
            {
                case TurretType.TURRET_TYPE_LASER:
                    if (laserLineRenderer.enabled)
                    {
                        laserLineRenderer.enabled = false;
                        laserImpactLight.enabled = false;
                        laserImpactEffect.Stop();
                    }
                    break;
            }
            return;
        }
        else
        {
            LockOnTarget();
            switch (turretType)
            {
                case TurretType.TURRET_TYPE_STANDARD:
                    currentFireRate -= Time.deltaTime;
                    if (currentFireRate <= 0)
                    {
                        ShootStandardBullet();
                        currentFireRate = fireRate;
                    }
                    break;
                case TurretType.TURRET_TYPE_CANNON:
                    currentFireRate -= Time.deltaTime;
                    if (currentFireRate <= 0)
                    {
                        ShootExplosionBullet();
                        currentFireRate = fireRate;
                    }
                    break;
                case TurretType.TURRET_TYPE_LASER:
                    Shootlaser();
                    break;
            }
        }
    }

    private void ShootStandardBullet()
    {
        GameObject bulletGameObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletGameObject.transform.parent = gameObject.transform;
    }

    private void ShootExplosionBullet()
    {
        GameObject standardBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        standardBullet.transform.parent = gameObject.transform;
    }

    private void Shootlaser()
    {
        if(laserLineRenderer.enabled == false)
        {
            laserLineRenderer.enabled = true;
            laserImpactLight.enabled = true;
            laserImpactEffect.Play();
        }
        laserLineRenderer.SetPosition(0, firePoint.position);
        laserLineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;
        laserImpactEffect.transform.position = target.position + dir.normalized;
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void UpdateTarget()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, radius, targetLayerMask);
        Transform shortestTarget = null;

        if (colls.Length > 0)
        {
            float shortestDistance = Mathf.Infinity;
            foreach (Collider collTarget in colls)
            {
                float distance = Vector3.SqrMagnitude(transform.position - collTarget.transform.position);
                if (shortestDistance > distance)
                {
                    shortestDistance = distance;
                    shortestTarget = collTarget.transform;
                }
            }
        }
        target = shortestTarget;
    }

    private void LockOnTarget()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position).normalized;
        Vector3 turretEuler = Quaternion.Lerp(partToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, turretEuler.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        if (fireRadiusGizmos)
        {
            Gizmos.color = fireRadiusGizmosColor;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
