using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {


    public string levelSelect;

    public GameObject PauseSystem;
    public Sprite TryAgain;
    public GameObject StartLevel;
    public GameObject Loose;
    public GameObject WorldParen;
    public GameObject MenuButton;
    public static StartMenu menu;
    string mainMenu = "Menu";

    public Text World;
    public Text Level;

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
            WorldParen.SetActive(false);
            Loose.SetActive(true);
            menu = this;
            DontDestroyOnLoad(menu);
            StartLevel.GetComponent<Image>().sprite = TryAgain;
            MenuButton.SetActive(true);
            
            
        }
    }
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 0f;
        int currentScene = SceneManager.GetActiveScene().buildIndex - 7;
        int world = (currentScene / 5)+1;
        int level = (currentScene - (5 * (world - 1)));
        if (level == 0) level = 5;
       
        switch(world)
        {
            case 1: World.text = "I"; break;
            case 2: World.text = "II"; break;
            case 3: World.text = "III"; break;
            case 4: World.text = "IV"; break;
            case 5: World.text = "V"; break;
            case 6: World.text = "VI"; break;
            case 7: World.text = "VII"; break;
            case 8: World.text = "VIII"; break;
            case 9: World.text = "IX"; break;
            case 10: World.text = "X"; break;
        }

        switch (level)
        {
            case 1: Level.text = "I"; break;
            case 2: Level.text = "II"; break;
            case 3: Level.text = "III"; break;
            case 4: Level.text = "IV"; break;
            case 5: Level.text = "V"; break;
        }
    }
  

    public void StartGame()
    {
        Time.timeScale = 1f;
      
        this.gameObject.SetActive(false);
        PauseSystem.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("LevelMenu");
        Invoke("DestroyMenu", 0.02f);
    }

    void DestroyMenu()
    {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
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
