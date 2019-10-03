using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject node;
    public GameObject ui;

    public TMP_Text damageDisplayer;
    public TMP_Text radiusDisplayer;

    public void SetTarget(Node _target)
    {
        target = _target;
        node.transform.position = target.GetBuildPosition();
        TurretBase turretBase = target.turret.GetComponent<TurretBase>();
        damageDisplayer.text = turretBase.damage.ToString();
        radiusDisplayer.text = turretBase.radius.ToString();

        node.SetActive(true);
        ui.SetActive(true);
    }

    public void Hide()
    {
        node.SetActive(false);
        ui.SetActive(false);
    }
}
