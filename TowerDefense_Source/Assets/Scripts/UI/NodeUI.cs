using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NodeUI : MonoBehaviour
{
    private Node target;
    private ShopUI shop;

    public GameObject nodeSelectObject;
    public GameObject nodeSelectUI;

    public Button upgradeButton;

    public TMP_Text upgradeCostDisplayer;
    public TMP_Text sellCostDisplayer;

    public void OpenNodeUI(Node _target)
    {
        target = _target;
        nodeSelectObject.transform.position = target.GetBuildPosition();


        if (target.isUpgraded == false)
        {
            upgradeCostDisplayer.text = "Upgrade\n<size=-10>$ " + target.turretBlueprint.upgradeCost.ToString() + "</size>";
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCostDisplayer.text = "Upgrade Done\n<size=-10>$ --- </size>";
            upgradeButton.interactable = false;
        }

        sellCostDisplayer.text = "Sell\n<size=-10>$ " + target.turretBlueprint.GetSellAmount().ToString() + "</size>";


        nodeSelectObject.SetActive(true);
        nodeSelectUI.SetActive(true);
    }

    public void CloseNodeUI()
    {
        nodeSelectObject.SetActive(false);
        nodeSelectUI.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        target.isUpgraded = false;
        BuildManager.instance.DeselectNode();
    }
}
