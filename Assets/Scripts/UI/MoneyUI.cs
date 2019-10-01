using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text moneyDisplayer;

    private void Update()
    {
        moneyDisplayer.text = "$ " + PlayerStats.Money.ToString();
    }
}
