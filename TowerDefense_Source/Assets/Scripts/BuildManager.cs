using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("\'BuildManager\' 컴포넌트를 포함한 \'GameObject\'가 존재하지 않습니다.");
        }
        instance = this;
    }

    public GameObject buildEffectPrefab = null;
    public GameObject sellEffectPrefab = null;

    public NodeUI nodeSelectUI;
    public ShopUI shopUI;

    private TurretBlueprint turretToBuild = null;
    private Node selectedNode = null;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        shopUI.CloseTurretBuyInfoWin();
        selectedNode = node;
        turretToBuild = null;
        nodeSelectUI.OpenNodeUI(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeSelectUI.CloseNodeUI();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
