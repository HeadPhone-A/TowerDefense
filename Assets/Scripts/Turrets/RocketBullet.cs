using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    private RocketTurret turret;
    private Transform target;
    private float damage;
    private float speed;
    private GameObject bulletImpactEffect;
    private LayerMask explosionTargetLayerMask;
    private float explosionRadius;

    private void Start()
    {
        turret = transform.parent.GetComponent<RocketTurret>();
        target = turret.target;
        damage = turret.damage;
        speed = turret.bulletSpeed;
        bulletImpactEffect = turret.bulletImpactEffect;
        explosionTargetLayerMask = turret.explosionTargetLayerMask;
        explosionRadius = turret.explosionRadius;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
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
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius, explosionTargetLayerMask);
        foreach (Collider coll in colls)
        {
            Damage(coll.transform);
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(damage);
        }
    }
}
