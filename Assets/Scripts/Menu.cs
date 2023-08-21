using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        File.Delete("levelsCountFile.txt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
