using UnityEditor;

[CustomEditor(typeof(StandardTurret_Upgraded))]
public class StandardTurret_Upgraded_Editor : Editor
{
    private SerializedProperty partToRotateProperty;
    private SerializedProperty firePointProperty;
    private SerializedProperty targetLayerMaskProperty;

    private SerializedProperty damageProperty;
    private SerializedProperty radiusProperty;
    private SerializedProperty turnSpeedProperty;
    private SerializedProperty fireRateProperty;

    private SerializedProperty bulletPrefabProperty;
    private SerializedProperty bulletImpactEffectProperty;
    private SerializedProperty bulletSpeedProperty;

    private SerializedProperty fireRadiusGizmosProperty;
    private SerializedProperty fireRadiusGizmosColorProperty;

    private void OnEnable()
    {
        partToRotateProperty = serializedObject.FindProperty("partToRotate");
        firePointProperty = serializedObject.FindProperty("firePoint");
        targetLayerMaskProperty = serializedObject.FindProperty("targetLayerMask");

        damageProperty = serializedObject.FindProperty("damage");
        radiusProperty = serializedObject.FindProperty("radius");
        turnSpeedProperty = serializedObject.FindProperty("turnSpeed");
        fireRateProperty = serializedObject.FindProperty("fireRate");

        bulletPrefabProperty = serializedObject.FindProperty("bulletPrefab");
        bulletImpactEffectProperty = serializedObject.FindProperty("bulletImpactEffect");
        bulletSpeedProperty = serializedObject.FindProperty("bulletSpeed");

        fireRadiusGizmosProperty = serializedObject.FindProperty("fireRadiusGizmos");
        fireRadiusGizmosColorProperty = serializedObject.FindProperty("fireRadiusGizmosColor");
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Unity Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(partToRotateProperty);
        EditorGUILayout.PropertyField(firePointProperty, true);
        EditorGUILayout.PropertyField(targetLayerMaskProperty);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Turret Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(damageProperty);
        EditorGUILayout.PropertyField(radiusProperty);
        EditorGUILayout.PropertyField(turnSpeedProperty);
        EditorGUILayout.PropertyField(fireRateProperty);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Bullet Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(bulletSpeedProperty);
        EditorGUILayout.PropertyField(bulletPrefabProperty);
        EditorGUILayout.PropertyField(bulletImpactEffectProperty);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Gizmos Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(fireRadiusGizmosProperty);
        EditorGUILayout.PropertyField(fireRadiusGizmosColorProperty);

        serializedObject.ApplyModifiedProperties();
    }

}
