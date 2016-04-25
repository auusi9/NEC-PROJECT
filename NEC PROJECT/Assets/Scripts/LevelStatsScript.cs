using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelStatsScript : MonoBehaviour {

    int world = 1;
    int level = 1;
    private int currentlevel = 1;

    public Text worldtext;
    public Text leveltext;
    public Text score;
    public Text attempts;
    public Text rebounds;

    // Use this for initialization
    void Start ()
    {
        ChangeLabels();
    }
	
	// Update is called once per frame

    public void ChangeWorldLeft()
    {
        world--;
        if (world == 0) world = 10;
        currentlevel = 5 * (world - 1) + level;
        ChangeLabels();
    }

    public void ChangeWorldRight()
    {
        world++;
        if (world == 11) world = 1;

        currentlevel = 5 * (world - 1) + level;
        ChangeLabels();
    }

    public void ChangeLevelLeft()
    {
        level--;
        if (level == 0) level = 5;
        currentlevel = 5 * (world - 1) + level;
        ChangeLabels();
    }

    public void ChangeLevelRight()
    {
        level++;
        if (level == 5) level = 1;
        currentlevel = 5 * (world - 1) + level;
        ChangeLabels();
    }


    void ChangeLabels()
    {
        switch (world)
        {
            case 1: worldtext.text = "I"; break;
            case 2: worldtext.text = "II"; break;
            case 3: worldtext.text = "III"; break;
            case 4: worldtext.text = "IV"; break;
            case 5: worldtext.text = "V"; break;
            case 6: worldtext.text = "VI"; break;
            case 7: worldtext.text = "VII"; break;
            case 8: worldtext.text = "VIII"; break;
            case 9: worldtext.text = "IX"; break;
            case 10: worldtext.text = "X"; break;
        }

        switch (level)
        {
            case 1: leveltext.text = "I"; break;
            case 2: leveltext.text = "II"; break;
            case 3: leveltext.text = "III"; break;
            case 4: leveltext.text = "IV"; break;
            case 5: leveltext.text = "V"; break;
        }

        if (currentlevel == 1)
            score.text = "" + PlayerPrefs.GetInt("NECSCENE" + "Score");
        else
            score.text = "" + PlayerPrefs.GetInt("NECSCENE" + currentlevel + "Score");
        if (PlayerPrefs.GetInt("NECSCENE" + currentlevel + "touches") == 1000000 || PlayerPrefs.GetInt("NECSCENE" + currentlevel + "attempts") == 0)
            rebounds.text = "-";
        else
        { 
        if (currentlevel == 1)
            rebounds.text = "" + PlayerPrefs.GetInt("NECSCENE" + "touches");
        else
            rebounds.text = "" + PlayerPrefs.GetInt("NECSCENE" + currentlevel + "touches");
        }
        if (currentlevel == 1)
            attempts.text = "" + PlayerPrefs.GetInt("NECSCENE" + "attempts");
        else
            attempts.text = "" + PlayerPrefs.GetInt("NECSCENE" + currentlevel + "attempts");

    }

    void StatsScene()
    {
        SceneManager.LoadScene("StatsScene");
    }
}
