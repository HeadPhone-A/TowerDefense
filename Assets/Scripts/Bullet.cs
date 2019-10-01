using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Turret turret;
    private Transform target;
    private float damage;
    private float speed;

    private GameObject bulletImpactEffect;
    private LayerMask explosionLayerMask;
    private float explosionRadius;

    private void Start()
    {
        turret = transform.parent.GetComponent<Turret>();
        target = turret.target;
        damage = turret.damage;
        speed = turret.bulletSpeed;

        switch (turret.turretType)
        {
            case TurretType.TURRET_TYPE_STANDARD:
                bulletImpactEffect = turret.bulletImpactEffect;
                break;
            case TurretType.TURRET_TYPE_CANNON:
                explosionLayerMask = turret.explosionLayerMask;
                bulletImpactEffect = turret.bulletImpactEffect;
                explosionRadius = turret.explosionRadius;
                break;
        }
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.transform);
    }

    private void HitTarget()
    {
        GameObject effectInstantiate = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstantiate, 2f);

        switch (turret.turretType)
        {
            case TurretType.TURRET_TYPE_STANDARD:
                Damage(target);
                break;
            case TurretType.TURRET_TYPE_CANNON:
                Explode();
                break;
        }
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius, explosionLayerMask);
        foreach(Collider coll in colls)
        {
            Damage(coll.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        if(enemyComponent != null)
        {
            enemyComponent.TakeDamage(damage);
        }
    }
}
