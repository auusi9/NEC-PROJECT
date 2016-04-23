using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StatsManager : MonoBehaviour {

    public static int TotalRebounds;
    public static int TotalAttempts;
    public static float TotalTime;
    public static int TotalScore;
    public static int TotalLevels;
    public static int TotalFragments;

    int seconds;
    int minute;
    int hour;
    public Text totalattempts;
    public Text totalrebounds;
    public Text totaltime;
    public Text totalscore;
    public Text totallevels;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        totallevels.text = "" + TotalLevels;
        totalattempts.text = "" +TotalAttempts;
        totalrebounds.text = "" + TotalRebounds;
        totalscore.text = "" + TotalScore;

        seconds = Mathf.RoundToInt(TotalTime) % 60;
        minute = (Mathf.RoundToInt(TotalTime) / 60) % 60;
        hour = (Mathf.RoundToInt(TotalTime) / 3600) % 24;

        Debug.Log(TotalTime);
       totaltime.text = "" + hour + "h " + minute + "m " + seconds + "s";
	}


    void LoadMainMenu()
    {
        FXManager.instance.PlayUIClickBack();
        SceneManager.LoadScene(0);
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        TotalAttempts = 0;
        TotalTime = 0f;
        TotalRebounds = 0;
        TotalScore = 0;
        TotalLevels = 0;
    }
    void UnlockLevels()
    {
        for(int i = 2; i <= 25;i++)
        {
            PlayerPrefs.SetInt("NECSCENE" + i, 1);
        }
    }





}




