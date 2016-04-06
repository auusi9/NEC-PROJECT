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
            level1_button.SetActive(true);
            level1_chosen.SetActive(true);
        }
        else if (col.gameObject.name == "Level2")
        {
            level2_button.SetActive(true);
            level2_chosen.SetActive(true);
        }
        else if (col.gameObject.name == "Level3")
        {
            level3_button.SetActive(true);
            level3_chosen.SetActive(true);  
        }
        else if (col.gameObject.name == "Level4")
        {
            level4_button.SetActive(true);
            level4_chosen.SetActive(true);
        }
        else if (col.gameObject.name == "Level5")
        {
            level5_button.SetActive(true);
            level5_chosen.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Level1")
        {
            level1_button.SetActive(false);
            level1_chosen.SetActive(false);
        }
        else if (col.gameObject.name == "Level2")
        {
            level2_button.SetActive(false);
            level2_chosen.SetActive(false);
        }
        else if (col.gameObject.name == "Level3")
        {
            level3_button.SetActive(false);
            level3_chosen.SetActive(false);
        }
        else if (col.gameObject.name == "Level4")
        {
            level4_button.SetActive(false);
            level4_chosen.SetActive(false);
        }
        else if (col.gameObject.name == "Level5")
        {
            level5_button.SetActive(false);
            level5_chosen.SetActive(false);
        }
    }
}
