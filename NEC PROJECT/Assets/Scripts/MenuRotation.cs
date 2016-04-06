using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuRotation : MonoBehaviour
{
    public GameObject textplay;
    public GameObject button_play_chosen;
    public GameObject light_chose;
    public GameObject TextSettings;
    public GameObject SettingsChosen;
    public GameObject TextStats;
    public GameObject StatsChosen;
    public GameObject TextAbout;
    public GameObject AboutChosen;

    float baseAngle2;
    void Start()
    {
        Time.timeScale = 1.0f;


    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("LevelMenu");
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
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "PlayButton")
        {
           
                textplay.SetActive(true);
                button_play_chosen.SetActive(true);
                light_chose.SetActive(true);
           
        }
        else if (col.gameObject.name == "SettingButton")
        {
            
                TextSettings.SetActive(true);
                SettingsChosen.SetActive(true);
                light_chose.SetActive(true);
            
        }
        else if (col.gameObject.name == "StatsButton")
        {
            
                TextStats.SetActive(true);
                StatsChosen.SetActive(true);
                light_chose.SetActive(true);
            
        }
        else if (col.gameObject.name == "AboutButton")
        {
           
                TextAbout.SetActive(true);
                AboutChosen.SetActive(true);
                light_chose.SetActive(true);
            
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayButton")
        {
           
                textplay.SetActive(false);
                button_play_chosen.SetActive(false);
                light_chose.SetActive(false);
            
        }
        else if (col.gameObject.name == "SettingButton")
        {
            
                TextSettings.SetActive(false);
                SettingsChosen.SetActive(false);
                light_chose.SetActive(false);
            
        }
        else if (col.gameObject.name == "StatsButton")
        {
            
                TextStats.SetActive(false);
                StatsChosen.SetActive(false);
                light_chose.SetActive(false);
            
        }
        else if (col.gameObject.name == "AboutButton")
        {
            
                TextAbout.SetActive(false);
                AboutChosen.SetActive(false);
                light_chose.SetActive(false);
            
        }
    }

    void onTouchDown(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = position - pos;
        baseAngle2 = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle2 -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;

    }

    void onTouchStay(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = position - pos;
        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle2;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
    }

    void onTouchUp()
    {
        //Add Code 
    }
    void onTouchExit()
    {
        //Add Code 
    }

}
