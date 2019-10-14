using UnityEditor;

[CustomEditor(typeof(LaserTurret))]
public class LaserTurret_Editor : Editor
{
    private SerializedProperty partToRotateProperty;
    private SerializedProperty firePointProperty;
    private SerializedProperty targetLayerMaskProperty;

    private SerializedProperty damageProperty;
    private SerializedProperty radiusProperty;
    private SerializedProperty turnSpeedProperty;

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

        damageProperty = serializedObject.FindProperty("damage");
        radiusProperty = serializedObject.FindProperty("radius");
        turnSpeedProperty = serializedObject.FindProperty("turnSpeed");

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
        EditorGUILayout.PropertyField(partToRotateProperty);
        EditorGUILayout.PropertyField(firePointProperty, true);
        EditorGUILayout.PropertyField(targetLayerMaskProperty);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Turret Settings ]", EditorStyles.boldLabel);
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
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("[ Gizmos Settings ]", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(fireRadiusGizmosProperty);
        EditorGUILayout.PropertyField(fireRadiusGizmosColorProperty);

        serializedObject.ApplyModifiedProperties();
    }
}
