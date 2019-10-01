using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject shop;

    public void OpenShop()
    {
        shop.SetActive(true);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }
}
