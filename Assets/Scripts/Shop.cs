using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public string name;
    public int cost;
    public Sprite icon;
}

public class Shop : MonoBehaviour
{
    [Header("[ UI Settings ]")]
    public GameObject turretBuyInfoWin = null;
    public TMP_Text turretBuyInfoWinTitle = null;
    public Image turretBuyInfoWinIcon = null;

    [Header("[ Turret Shop Settings ]")]
    public TurretBlueprint standardTurret;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint laserTurret;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void TurretBuyInfoWinUpdate(TurretBlueprint turret)
    {
        turretBuyInfoWinTitle.text = "BUY " + turret.name;
        turretBuyInfoWinIcon.sprite = turret.icon;
        turretBuyInfoWin.SetActive(true);
    }

    public void CloseTurretBuyInfoWin()
    {
        turretBuyInfoWin.SetActive(false);
        buildManager.SelectTurretToBuild(null);
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
        TurretBuyInfoWinUpdate(standardTurret);
        gameObject.SetActive(false);
    }

    public void SelectRocketTurret()
    {
        buildManager.SelectTurretToBuild(rocketTurret);
        TurretBuyInfoWinUpdate(rocketTurret);
        gameObject.SetActive(false);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
        TurretBuyInfoWinUpdate(laserTurret);
        gameObject.SetActive(false);
    }
}
