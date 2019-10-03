﻿using UnityEngine;

public class StandardBullet : MonoBehaviour
{
    private StandardTurret turret;
    private Transform target;
    private float damage;
    private float speed;
    private GameObject bulletImpactEffect;

    private void Start()
    {
        turret = transform.parent.GetComponent<StandardTurret>();
        target = turret.target;
        damage = turret.damage;
        speed = turret.bulletSpeed;
        bulletImpactEffect = turret.bulletImpactEffect;
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
        Damage(target);
        Destroy(gameObject);
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
