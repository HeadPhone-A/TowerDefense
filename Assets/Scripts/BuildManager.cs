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
    public NodeUI nodeUI;
    public Shop shop;

    private TurretBlueprint turretToBuild = null;
    private Node selectedNode = null;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(turretToBuild == null) { return; }
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab,
                            new Vector3(node.transform.position.x, node.transform.position.y + 0.25f, node.transform.position.z),
                            Quaternion.identity) as GameObject;
        node.turret = turret;

        GameObject effect = Instantiate(buildEffectPrefab, node.GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 5f);

        Debug.Log("포탑 건설 성공! 남은 소지금: " + PlayerStats.Money);
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        shop.CloseTurretBuyInfoWin();
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;
        nodeUI.Hide();
    }
}
