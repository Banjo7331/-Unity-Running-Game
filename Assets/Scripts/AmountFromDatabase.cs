using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AmountFromDatabase : MonoBehaviour
{
    private int coins;
    private bool modell1 = true;
    private bool modell2 = false;
    private bool modell1Avaibility = true;
    private bool modell2Avaibility = false;
    private const string Shoppt = "Shoop.txt";
    [SerializeField] TextMeshProUGUI moneyText;
    private class Shop
    {
        public int Coins;
        public bool[] model1;
        public bool[] model2;
    }
    void Start()
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
            moneyText.text = Mathf.RoundToInt(coins).ToString();
        }
    }

}
