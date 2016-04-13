using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    string levelSelect;

    string mainMenu;

    public GameObject Pause_Menu;

    // Use this for initialization
    void Start()
    {
        mainMenu = "MainMenu";
        levelSelect = "LevelMenu";
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Pause_Menu.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
        Pause_Menu.SetActive(false);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        Destroy(StartMenu.menu.gameObject);
        TouchesScript.touches = 0;
        StatsManager.TotalTime += Time.timeSinceLevelLoad;
        PlayerPrefs.SetFloat("TotalTime", StatsManager.TotalTime);
        PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
        SceneManager.LoadScene(levelSelect);  
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Destroy(StartMenu.menu.gameObject);
        TouchesScript.touches = 0;
        StatsManager.TotalTime += Time.timeSinceLevelLoad;
        PlayerPrefs.SetFloat("TotalTime", StatsManager.TotalTime);
        PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
        SceneManager.LoadScene(mainMenu);

    }
}
