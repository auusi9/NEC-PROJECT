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
        Pause_Menu.SetActive(false);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        Destroy(StartMenu.menu.gameObject);
        SceneManager.LoadScene(levelSelect);
       
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Destroy(StartMenu.menu.gameObject);
        SceneManager.LoadScene(mainMenu);

    }
}
