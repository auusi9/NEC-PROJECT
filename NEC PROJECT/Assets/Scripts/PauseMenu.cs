using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public string levelSelect;

    public string mainMenu;

    public GameObject Pause_Menu;

    // Use this for initialization
    void Start()
    {
        mainMenu = "MainMenu";
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
        SceneManager.LoadScene(levelSelect);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }
}
