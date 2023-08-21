using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public Button thisButton; 
    public Button thisButton2;
    public GameObject skinChangerMenu;
    private const string Shoppt = "Shoop.txt";
    private bool modell1;
    private bool modell2;
    private int coins;
    // Start is called before the first frame update

    private class Shop
    {
        public int Coins;
        public bool model1;
        public bool model2;
    }

    public void Choose()
    {
        thisButton.GetComponent<Image>().color = Color.green;
        thisButton2.GetComponent<Image>().color = Color.gray;
    }
    public void GoOutOfTheShop()
    {
        skinChangerMenu.SetActive(false);
        thisButton.GetComponent<Image>().color = Color.gray;
        thisButton2.GetComponent<Image>().color = Color.gray;
    }
    public void ChooseCube()
    {
        if (File.Exists(Shoppt))
        {
            var jsonString = File.ReadAllText(Shoppt);
            var shoop = JsonUtility.FromJson<Shop>(jsonString);
            if (shoop != null)
            {
                coins = shoop.Coins;
                modell1 = shoop.model1;
                modell2 = shoop.model2;
            }

            var saveResults = new Shop
            {
                Coins = coins,
                model1 = true,
                model2 = false
            };

            var shopToSave = JsonUtility.ToJson(saveResults, true);

            File.WriteAllText(Shoppt, shopToSave);
        }

        
    }
    public void ChooseSphere()
    {
        if (File.Exists(Shoppt))
        {
            var jsonString = File.ReadAllText(Shoppt);
            var shoop = JsonUtility.FromJson<Shop>(jsonString);
            if (shoop != null)
            {
                coins = shoop.Coins;
                modell1 = shoop.model1;
                modell2 = shoop.model2;
            }

            var saveResults = new Shop
            {
                Coins = coins,
                model1 = false,
                model2 = true
            };

            var shopToSave = JsonUtility.ToJson(saveResults, true);

            File.WriteAllText(Shoppt, shopToSave);
        }

        
    }
}
