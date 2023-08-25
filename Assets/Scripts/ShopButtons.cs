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
    private bool modell1Avaibility;
    private bool modell2Avaibility;
    private int coins;
    // Start is called before the first frame update

    private class Shop
    {
        public int Coins;
        public bool[] model1;
        public bool[] model2;
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
                modell1 = shoop.model1[0];
                modell2 = shoop.model2[0];
                modell1Avaibility = shoop.model1[1];
                modell2Avaibility = shoop.model2[1];
            }
            
            if (modell1Avaibility)
            {
                var saveResults = new Shop
                {
                    Coins = coins,
                    model1 = new bool[] { true, modell1Avaibility },//true,
                    model2 = new bool[] { false, modell2Avaibility },
                };

                var shopToSave = JsonUtility.ToJson(saveResults, true);

                File.WriteAllText(Shoppt, shopToSave);
            }
            
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
                modell1 = shoop.model1[0];
                modell2 = shoop.model2[0];
                modell1Avaibility = shoop.model1[1];
                modell2Avaibility = shoop.model2[1];
            }
            
            if(modell2Avaibility)
            {
                var saveResults = new Shop
                {
                    Coins = coins,
                    model1 = new bool[] { false, modell1Avaibility },//true,
                    model2 = new bool[] { true, modell2Avaibility },
                };

                var shopToSave = JsonUtility.ToJson(saveResults, true);

                File.WriteAllText(Shoppt, shopToSave);
            }
            
        }

        
    }
}
