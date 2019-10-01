using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Turret))]
public class TurretScriptEditor : Editor
{
    private SerializedProperty targetLayerMaskProperty;
    private SerializedProperty partToRotateProperty;
    private SerializedProperty firePointProperty;

    private SerializedProperty turretTypeProperty;
    private SerializedProperty damageProperty;
    private SerializedProperty radiusProperty;
    private SerializedProperty turnSpeedProperty;
    private SerializedProperty fireRateProperty;

    private SerializedProperty bulletPrefabProperty;
    private SerializedProperty bulletSpeedProperty;
    private SerializedProperty bulletImpactEffectProperty;

    private SerializedProperty explosionLayerMaskProperty;
    private SerializedProperty explosionRadiusProperty;

    private SerializedProperty laserLineRendererProperty;
    private SerializedProperty laserImpactEffectProperty;

    private SerializedProperty laserSlowPercentProperty;

    private SerializedProperty fireRadiusGizmosProperty;
    private SerializedProperty fireRadiusGizmosColorProperty;

    private void OnEnable()
    {

        targetLayerMaskProperty = serializedObject.FindProperty("targetLayerMask");
        partToRotateProperty = serializedObject.FindProperty("partToRotate");
        firePointProperty = serializedObject.FindProperty("firePoint");

        turretTypeProperty = serializedObject.FindProperty("turretType");
        damageProperty = serializedObject.FindProperty("damage");
        radiusProperty = serializedObject.FindProperty("radius");
        turnSpeedProperty = serializedObject.FindProperty("turnSpeed");
        fireRateProperty = serializedObject.FindProperty("fireRate");

        bulletPrefabProperty = serializedObject.FindProperty("bulletPrefab");
        bulletSpeedProperty = serializedObject.FindProperty("bulletSpeed");
        bulletImpactEffectProperty = serializedObject.FindProperty("bulletImpactEffect");

        explosionLayerMaskProperty = serializedObject.FindProperty("explosionLayerMask");
        explosionRadiusProperty = serializedObject.FindProperty("explosionRadius");

        laserLineRendererProperty = serializedObject.FindProperty("laserLineRenderer");
        laserImpactEffectProperty = serializedObject.FindProperty("laserImpactEffect");

        laserSlowPercentProperty = serializedObject.FindProperty("laserSlowPercent");

        fireRadiusGizmosProperty = serializedObject.FindProperty("fireRadiusGizmos");
        fireRadiusGizmosColorProperty = serializedObject.FindProperty("fireRadiusGizmosColor");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Unity Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(targetLayerMaskProperty);
        EditorGUILayout.PropertyField(partToRotateProperty);
        EditorGUILayout.PropertyField(firePointProperty);

        switch ((TurretType)turretTypeProperty.intValue)
        {
            case TurretType.TURRET_TYPE_STANDARD:
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Turret Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(turretTypeProperty);
                EditorGUILayout.PropertyField(damageProperty);
                EditorGUILayout.PropertyField(radiusProperty);
                EditorGUILayout.PropertyField(turnSpeedProperty);
                EditorGUILayout.PropertyField(fireRateProperty);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Bullet Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(bulletPrefabProperty);
                EditorGUILayout.PropertyField(bulletSpeedProperty);
                EditorGUILayout.PropertyField(bulletImpactEffectProperty);
                break;
            case TurretType.TURRET_TYPE_CANNON:
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Turret Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(turretTypeProperty);
                EditorGUILayout.PropertyField(damageProperty);
                EditorGUILayout.PropertyField(radiusProperty);
                EditorGUILayout.PropertyField(turnSpeedProperty);
                EditorGUILayout.PropertyField(fireRateProperty);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Bullet Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(bulletPrefabProperty);
                EditorGUILayout.PropertyField(bulletSpeedProperty);
                EditorGUILayout.PropertyField(bulletImpactEffectProperty);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Explosion Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(explosionLayerMaskProperty);
                EditorGUILayout.PropertyField(explosionRadiusProperty);
                break;
            case TurretType.TURRET_TYPE_LASER:
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Turret Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(turretTypeProperty);
                EditorGUILayout.PropertyField(damageProperty);
                EditorGUILayout.PropertyField(radiusProperty);
                EditorGUILayout.PropertyField(turnSpeedProperty);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Laser Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(laserLineRendererProperty);
                EditorGUILayout.PropertyField(laserImpactEffectProperty);
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("[ Slow Settings ]", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(laserSlowPercentProperty);
                break;
        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Gizmos Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(fireRadiusGizmosProperty);
        EditorGUILayout.PropertyField(fireRadiusGizmosColorProperty);

        serializedObject.ApplyModifiedProperties();
    }
}
