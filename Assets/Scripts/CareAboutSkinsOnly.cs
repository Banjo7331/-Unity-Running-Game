using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CareAboutSkinsOnly : MonoBehaviour
{
    public Button but;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI amount;
    private const string Shoppt = "Shoop.txt";
    private int coins;
    private bool modell1 = true;
    private bool modell2 = false;
    private bool modell1Avaibility = true;
    private bool modell2Avaibility = false;
    private int valueOfSkin;



    private class Shop
    {
        public int Coins;
        public bool[] model1;
        public bool[] model2;
    }
    void Start()
    {
        valueOfSkin = int.Parse(scoreText.text);
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
        }
        if(modell2Avaibility)
        {
            scoreText.color = Color.green;
            scoreText.text = "Gottem";
        }
    }

    public void TheBlockedOne()
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

            if (coins >= valueOfSkin && !modell2Avaibility)
            {
                var saveResults = new Shop
                {
                    Coins = coins - valueOfSkin,
                    model1 = new bool[] { modell1, modell1Avaibility },
                    model2 = new bool[] { modell2, true },
                };

                var shopToSave = JsonUtility.ToJson(saveResults, true);

                File.WriteAllText(Shoppt, shopToSave);
                amount.text = saveResults.Coins.ToString();
                scoreText.color = Color.green;
                scoreText.text = "Gottem";
            }
            else if (coins < valueOfSkin && !modell2Avaibility)
            {
                scoreText.color = Color.red;
                scoreText.text = "Not Enough:<";
            }
        }

    }
}
