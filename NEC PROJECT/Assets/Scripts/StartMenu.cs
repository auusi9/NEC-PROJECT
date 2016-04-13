using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour {


    public string levelSelect;

    public GameObject PauseSystem;
    public GameObject TryAgain;
    public static StartMenu menu;
    string mainMenu = "Menu";

    void Awake()
    {
        if (menu == null)
        {
            menu = this;
            DontDestroyOnLoad(menu);
        }
        else if (menu != this)
        {
            Destroy(menu.gameObject);
            menu = this;
            DontDestroyOnLoad(menu);
            TryAgain.SetActive(true);
            
            
        }
    }
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0f;
    }
    

    public void StartGame()
    {
        Time.timeScale = 1f;
      
        this.gameObject.SetActive(false);
        PauseSystem.SetActive(true);
     

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
