using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class MenuResp : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    private GameObject current;
    private int coins;
    private bool modell1;
    private bool modell2;
    private bool modell1Avaibility = true;
    private bool modell2Avaibility = false;
    private bool modell1Curent;
    private bool modell2Curent;
    private Vector3 currentPosition;
    private const string Shoppt = "Shoop.txt";


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
        }
        modell1Curent = modell1;
        modell2Curent = modell2;
        if (modell1Curent == true)
        {
            current = Instantiate(model1, transform.position, Quaternion.identity);
        }
        else
        {
            current = Instantiate(model2, transform.position, Quaternion.identity);
        }


    }
    public void Update()
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
        }

        if (modell1 == modell1Curent)
        {
            ;
        }
        else
        {
            currentPosition = current.transform.position;
            Destroy(current);
            modell1Curent = modell1;
            modell2Curent = modell2;
            Check(currentPosition);
        }
    }
    public void Check(Vector3 pos)
    {
        if (modell1Curent == true)
        {
            current = Instantiate(model1, pos, Quaternion.identity);
        }
        else
        {
            current = Instantiate(model2, pos, Quaternion.identity);
        }
    }

}
