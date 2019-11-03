using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public Transform target;
    public Transform partToRotate = null;
    public LayerMask targetLayerMask = 0;

    public float damage = 20f;
    public float radius = 10f;
    public float turnSpeed = 7.5f;

    public bool fireRadiusGizmos = true;
    public Color fireRadiusGizmosColor = Color.red;

    public Enemy targetEnemy;

    protected virtual void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    protected virtual void Update()
    {
        UpdateTurretRotate();
    }

    protected virtual void UpdateTurretRotate()
    {
        if (target == null)
        {
            partToRotate.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
        }
        else
        {
            Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position).normalized;
            Vector3 turretEuler = Quaternion.Lerp(partToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, turretEuler.y, 0f);
        }
    }

    protected virtual void UpdateTarget()
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
        if (target != null)
        {
            targetEnemy = target.GetComponent<Enemy>();
        }
    }

    protected virtual void OnDrawGizmosSelected()
    {
        if (fireRadiusGizmos)
        {
            Gizmos.color = fireRadiusGizmosColor;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
