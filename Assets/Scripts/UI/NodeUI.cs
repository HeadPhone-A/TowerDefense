using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject nodeSelectObject;
    public GameObject nodeSelectUI;

    //public TMP_Text damageDisplayer;
    //public TMP_Text radiusDisplayer;

    public void SetTarget(Node _target)
    {
        target = _target;
        nodeSelectObject.transform.position = target.GetBuildPosition();
        TurretBase turretBase = target.turret.GetComponent<TurretBase>();
        //damageDisplayer.text = turretBase.damage.ToString();
        //radiusDisplayer.text = turretBase.radius.ToString();

        nodeSelectObject.SetActive(true);
        nodeSelectUI.SetActive(true);
    }

    public void Hide()
    {
        nodeSelectObject.SetActive(false);
        nodeSelectUI.SetActive(false);
    }
}
