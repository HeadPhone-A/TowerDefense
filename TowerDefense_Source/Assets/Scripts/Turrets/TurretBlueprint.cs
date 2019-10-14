using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public string name;
    public Sprite icon;

    [Space]
    public GameObject prefab;
    public int cost;

    [Space]
    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}