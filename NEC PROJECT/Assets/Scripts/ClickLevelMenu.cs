using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickLevelMenu : MonoBehaviour {

    public GameObject level1_chosen;
    public GameObject level2_chosen;
    public GameObject level3_chosen;
    public GameObject level4_chosen;
    public GameObject level5_chosen;

    public GameObject level1_button;
    public GameObject level2_button;
    public GameObject level3_button;
    public GameObject level4_button;
    public GameObject level5_button;

    public GameObject light_chose;

    public GameObject[] button;
    void Start()
    {
        Time.timeScale = 1.0f;


    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("UILevels");
    }

    public void OnStartGame()
    {
        //Debug.Log("You pressed play button!");
        //Add load for new scene here.
        LoadPlayScene();

    }
    public void OnSettingsGame()
    {
        Debug.Log("You pressed settings button!");
        //Add load for new scene here.


    }
    public void OnStatsGame()
    {
        Debug.Log("You pressed Stats button!");
        //Add load for new scene here.


    }
    public void OnAboutGame()
    {
        Debug.Log("You pressed About us button!");
        //Add load for new scene here.


    }

    

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Level1")
        {
            switch(LevelManager.world)
            {
                case 1:
                        level1_chosen.SetActive(true);
                        break;
                    
                case 2:
                    if (PlayerPrefs.GetInt("NECSCENE6") == 1)
                    { 
                        level1_chosen.SetActive(true);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("NECSCENE11") == 1)
                    {
                        level1_chosen.SetActive(true);
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("NECSCENE16") == 1)
                    {    
                        level1_chosen.SetActive(true);
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("NECSCENE21") == 1)
                    {   
                        level1_chosen.SetActive(true);
                    }
                    break;
            }
            level1_button.SetActive(true);
            button[0].SetActive(true);

        }
        else if (col.gameObject.name == "Level2")
        {
            switch (LevelManager.world)
            {
                case 1:
                    if (PlayerPrefs.GetInt("NECSCENE2") == 1)
                    {
                        level2_chosen.SetActive(true);
                    }
                    break;

                case 2:
                    if (PlayerPrefs.GetInt("NECSCENE7") == 1)
                    {
                        level2_chosen.SetActive(true);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("NECSCENE12") == 1)
                    {
                        level2_chosen.SetActive(true);
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("NECSCENE17") == 1)
                    {   
                        level2_chosen.SetActive(true);
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("NECSCENE22") == 1)
                    {  
                        level2_chosen.SetActive(true);
                    }
                    break;
            }
            level2_button.SetActive(true);
            button[1].SetActive(true);
        }
        else if (col.gameObject.name == "Level3")
        {
            switch (LevelManager.world)
            {
                case 1:
                    if (PlayerPrefs.GetInt("NECSCENE3") == 1)
                    {   
                        level3_chosen.SetActive(true);
                    }
                    break;

                case 2:
                    if (PlayerPrefs.GetInt("NECSCENE8") == 1)
                    {
                        level3_chosen.SetActive(true);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("NECSCENE13") == 1)
                    {
                        level3_chosen.SetActive(true);
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("NECSCENE18") == 1)
                    {
                        level3_chosen.SetActive(true);
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("NECSCENE23") == 1)
                    {
                        level3_chosen.SetActive(true);
                    }
                    break;
            }
            level3_button.SetActive(true);
            button[2].SetActive(true);

        }
        else if (col.gameObject.name == "Level4")
        {
            switch (LevelManager.world)
            {
                case 1:
                    if (PlayerPrefs.GetInt("NECSCENE4") == 1)
                    { 
                        level4_chosen.SetActive(true);
                    }
                    break;

                case 2:
                    if (PlayerPrefs.GetInt("NECSCENE9") == 1)
                    {
                        level4_chosen.SetActive(true);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("NECSCENE14") == 1)
                    {
                        level4_chosen.SetActive(true);
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("NECSCENE19") == 1)
                    {
                        level4_chosen.SetActive(true);
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("NECSCENE24") == 1)
                    {
                        level4_chosen.SetActive(true);
                    }
                    break;
            }
            level4_button.SetActive(true);
            button[3].SetActive(true);
        }
        else if (col.gameObject.name == "Level5")
        {
            switch (LevelManager.world)
            {
                case 1:
                    if (PlayerPrefs.GetInt("NECSCENE5") == 1)
                    {
                        level5_chosen.SetActive(true);
                    }
                    break;

                case 2:
                    if (PlayerPrefs.GetInt("NECSCENE10") == 1)
                    {
                        level5_chosen.SetActive(true);
                    }
                    break;
                case 3:
                    if (PlayerPrefs.GetInt("NECSCENE15") == 1)
                    {
                        level5_chosen.SetActive(true);
                    }
                    break;
                case 4:
                    if (PlayerPrefs.GetInt("NECSCENE20") == 1)
                    {
                        level5_chosen.SetActive(true);
                    }
                    break;
                case 5:
                    if (PlayerPrefs.GetInt("NECSCENE25") == 1)
                    {
                        level5_chosen.SetActive(true);
                    }
                    break;
            }
            level5_button.SetActive(true);
            button[4].SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Level1")
        {
            level1_button.SetActive(false);
            level1_chosen.SetActive(false);
            button[0].SetActive(false);
        }
        else if (col.gameObject.name == "Level2")
        {
            level2_button.SetActive(false);
            level2_chosen.SetActive(false);
            button[1].SetActive(false);
        }
        else if (col.gameObject.name == "Level3")
        {
            level3_button.SetActive(false);
            level3_chosen.SetActive(false);
            button[2].SetActive(false);
        }
        else if (col.gameObject.name == "Level4")
        {
            level4_button.SetActive(false);
            button[3].SetActive(false);
            level4_chosen.SetActive(false);
        }
        else if (col.gameObject.name == "Level5")
        {
            level5_button.SetActive(false);
            button[4].SetActive(false);
            level5_chosen.SetActive(false);
        }
    }
}
