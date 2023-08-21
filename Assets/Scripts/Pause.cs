using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseMenu;
    public GameObject skinChangerMenu;

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void GoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void GoShop()
    {
        skinChangerMenu.SetActive(true);
    }

}
