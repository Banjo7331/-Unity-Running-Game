using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferToShop : MonoBehaviour
{
    public GameObject shopMenu;

    public void GoTo()
    {
        shopMenu.SetActive(true);
    }

    public void GoBack()
    {
        shopMenu.SetActive(false);
    }
    public void TheBlockedSkin()
    {

    }
}
