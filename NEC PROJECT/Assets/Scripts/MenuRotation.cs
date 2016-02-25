using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuRotation : MonoBehaviour
{


    
    private float baseAngle = 0.0f;
    public GameObject textplay;
    public GameObject button_play_chosen;
    public GameObject light_chose;
    public GameObject TextSettings;
    public GameObject SettingsChosen;
    public GameObject TextStats;
    public GameObject StatsChosen;
    public GameObject TextAbout;
    public GameObject AboutChosen;



    void Start()
    {
        if (textplay.gameObject.tag == "TextPlay" &&
            button_play_chosen.gameObject.tag == "PlayChosen" &&
            light_chose.gameObject.tag == "ChosenLight" &&
            TextSettings.gameObject.tag == "TextSettings" &&
            SettingsChosen.gameObject.tag == "SettingsChosen" &&
            TextStats.gameObject.tag == "TextStats" &&
            StatsChosen.gameObject.tag == "StatsChosen" &&
            TextAbout.gameObject.tag == "TextAbout" &&
            AboutChosen.gameObject.tag == "AboutChosen")
        {      
            textplay.SetActive(false);
            button_play_chosen.SetActive(false);
            TextSettings.SetActive(false);
            SettingsChosen.SetActive(false);
            TextStats.SetActive(false);
            StatsChosen.SetActive(false);
            TextAbout.SetActive(false);
            AboutChosen.SetActive(false);
            light_chose.SetActive(false);
        }
    }

   
    public void getSound (string soundName)
    {
        switch (soundName)
        {
            case "btn01_onClick":
                //put sound here!
                Debug.Log("btn01_onClick");
                break;
        }
    }

    void OnMouseDown()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
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

        if (col.gameObject.name == "UI_Circle_Play_Regular")
        {
            if (textplay.gameObject.tag == "TextPlay")
            {
                textplay.SetActive(true);
                button_play_chosen.SetActive(true);
                light_chose.SetActive(true);
            }
        }
        else if (col.gameObject.name == "UI_Circle_Settings_Regular")
        {
            if (TextSettings.gameObject.tag == "TextSettings")
            {
                TextSettings.SetActive(true);
                SettingsChosen.SetActive(true);
                light_chose.SetActive(true);
            }
        }
        else if (col.gameObject.name == "UI_Circle_Stats_Regular")
        {
            if (TextStats.gameObject.tag == "TextStats")
            {
                TextStats.SetActive(true);
                StatsChosen.SetActive(true);
                light_chose.SetActive(true);
            }
        }
        else if (col.gameObject.name == "UI_Circle_About_Regular")
        {
            if (TextAbout.gameObject.tag == "TextAbout")
            {
                TextAbout.SetActive(true);
                AboutChosen.SetActive(true);
                light_chose.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "UI_Circle_Play_Regular")
        {
            if (textplay.gameObject.tag == "TextPlay")
            {
                textplay.SetActive(false);
                button_play_chosen.SetActive(false);
                light_chose.SetActive(false);
            }
        }
        else if (col.gameObject.name == "UI_Circle_Settings_Regular")
        {
            if (TextSettings.gameObject.tag == "TextSettings")
            {
                TextSettings.SetActive(false);
                SettingsChosen.SetActive(false);
                light_chose.SetActive(false);
            }
        }
        else if (col.gameObject.name == "UI_Circle_Stats_Regular")
        {
            if (TextStats.gameObject.tag == "TextStats")
            {
                TextStats.SetActive(false);
                StatsChosen.SetActive(false);
                light_chose.SetActive(false);
            }
        }
        else if (col.gameObject.name == "UI_Circle_About_Regular")
        {
            if (TextAbout.gameObject.tag == "TextAbout")
            {
                TextAbout.SetActive(false);
                AboutChosen.SetActive(false);
                light_chose.SetActive(false);
            }
        }
    }


}
