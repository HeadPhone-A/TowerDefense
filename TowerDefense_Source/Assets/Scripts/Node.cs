using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    public Vector3 positionOffset;

    private Color defaultColor;

    private Renderer rend;                  //{ get { return GetComponent<Renderer>(); } }
    private BuildManager buildManager;      //{ get { return BuildManager.instance; } }
    private SoundManager soundManager;      //{ get { return SoundManager.instance; } }
    private GameObject shopUI;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        buildManager = BuildManager.instance;
        soundManager = SoundManager.instance;
        defaultColor = rend.material.color;
        shopUI = GameObject.Find("UI").transform.Find("Shop_UI").gameObject;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if(turret != null)
        {
            if (shopUI.activeSelf)
            {
                return;
            }
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());
    }
    
    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (blueprint == null) { return; }
        if (PlayerStats.Money < blueprint.cost)
        {
            soundManager.PlaySoundEffect("Error");
            Debug.Log("돈이 부족합니다.");
            return;
        }

        soundManager.PlaySoundEffect("ItemPurchase");

        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity) as GameObject;
        turret = _turret;

        GameObject effect = Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 5f);

        turretBlueprint = blueprint;

        Debug.Log("포탑 건설 성공! 남은 소지금: " + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            soundManager.PlaySoundEffect("Error");
            Debug.Log("돈이 부족합니다.");
            return;
        }

        soundManager.PlaySoundEffect("ItemPurchase");

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //기존 포탑 제거
        Destroy(turret);

        //업그레이드 포탑 설치
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity) as GameObject;
        turret = _turret;

        GameObject effect = Instantiate(buildManager.buildEffectPrefab, GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("포탑 업그레이드 성공! 남은 소지금: " + PlayerStats.Money);
    }

    public void SellTurret()
    {
        soundManager.PlaySoundEffect("ItemPurchase");

        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);

        GameObject effect = Instantiate(buildManager.sellEffectPrefab, GetBuildPosition(), Quaternion.identity) as GameObject;
        Destroy(effect, 5f);

        turretBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        rend.material.color = defaultColor;
    }
}
