using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject shop;

    public void OpenShop()
    {
        SoundManager.instance.PlaySoundEffect("Click");
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        SoundManager.instance.PlaySoundEffect("Click");
        shop.SetActive(false);
    }
}
