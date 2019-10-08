using UnityEngine;

public class LaserTurret : TurretBase
{
    public LineRenderer laserLineRenderer;
    public ParticleSystem laserImpactEffect;

    [Range(0, 100)]
    public float laserSlowPercent;

    private Light laserImpactLight;

    protected override void Start()
    {
        base.Start();
        laserImpactLight = laserImpactEffect.GetComponentInChildren<Light>();
    }

    protected override void Update()
    {
        base.Update();
        if (target != null)
        {
            ShootLaser();
        }
        else
        {
            laserLineRenderer.enabled = false;
            laserImpactLight.enabled = false;
            laserImpactEffect.Stop();
        }
    }

    private void ShootLaser()
    {
        targetEnemy.TakeDamage(damage * Time.deltaTime);
        targetEnemy.Slow(laserSlowPercent / 100);
        if (laserLineRenderer.enabled == false)
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
}