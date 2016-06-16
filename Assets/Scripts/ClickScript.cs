using UnityEngine;
using System.Collections;

public class ClickScript : MonoBehaviour {

    public GameObject textplay;
    public GameObject button_play_chosen;
    public GameObject TextSettings;
    public GameObject SettingsChosen;
    public GameObject TextStats;
    public GameObject StatsChosen;
    public GameObject TextAbout;
    public GameObject AboutChosen;

    public GameObject[] button;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "PlayButton")
        {

            textplay.SetActive(true);
            button_play_chosen.SetActive(true);
            button[0].SetActive(true);


        }
        else if (col.gameObject.name == "SettingButton")
        {

            TextSettings.SetActive(true);
            SettingsChosen.SetActive(true);
            button[3].SetActive(true);


        }
        else if (col.gameObject.name == "StatsButton")
        {

            TextStats.SetActive(true);
            StatsChosen.SetActive(true);
            button[1].SetActive(true);


        }
        else if (col.gameObject.name == "AboutButton")
        {

            TextAbout.SetActive(true);
            AboutChosen.SetActive(true);
            button[2].SetActive(true);


        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "PlayButton")
        {

            textplay.SetActive(false);
            button_play_chosen.SetActive(false);
            button[0].SetActive(false);


        }
        else if (col.gameObject.name == "SettingButton")
        {

            TextSettings.SetActive(false);
            SettingsChosen.SetActive(false);
            button[3].SetActive(false);


        }
        else if (col.gameObject.name == "StatsButton")
        {

            TextStats.SetActive(false);
            StatsChosen.SetActive(false);
            button[1].SetActive(false);

        }
        else if (col.gameObject.name == "AboutButton")
        {

            TextAbout.SetActive(false);
            AboutChosen.SetActive(false);
            button[2].SetActive(false);

        }
    }
}
