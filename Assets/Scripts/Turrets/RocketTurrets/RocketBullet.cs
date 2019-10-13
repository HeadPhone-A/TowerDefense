using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    private RocketTurret turret;
    protected Transform target;
    protected float damage;
    protected float speed;
    protected GameObject bulletImpactEffect;
    protected LayerMask explosionTargetLayerMask;
    protected float explosionRadius;

    protected virtual void Start()
    {
        turret = transform.parent.GetComponent<RocketTurret>();
        target = turret.target;
        damage = turret.damage;
        speed = turret.bulletSpeed;
        bulletImpactEffect = turret.bulletImpactEffect;
        explosionTargetLayerMask = turret.explosionTargetLayerMask;
        explosionRadius = turret.explosionRadius;
    }

    protected virtual void Update()
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

    protected void HitTarget()
    {
        GameObject effectInstantiate = Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstantiate, 2f);
        Explode();
        Destroy(gameObject);
    }

    protected void Explode()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, explosionRadius, explosionTargetLayerMask);
        foreach (Collider coll in colls)
        {
            Damage(coll.transform);
        }
    }

    protected void Damage(Transform enemy)
    {
        Enemy enemyComponent = enemy.GetComponent<Enemy>();

        if (enemyComponent != null)
        {
            enemyComponent.TakeDamage(damage);
        }
    }
}
