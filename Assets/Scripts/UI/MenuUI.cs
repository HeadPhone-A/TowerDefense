using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject shop;
    public NodeUI nodeUI;

    public void OpenShop()
    {
        SoundManager.instance.PlaySoundEffect("Click");
        nodeUI.CloseNodeUI();
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        SoundManager.instance.PlaySoundEffect("Click");
        shop.SetActive(false);
    }
}
