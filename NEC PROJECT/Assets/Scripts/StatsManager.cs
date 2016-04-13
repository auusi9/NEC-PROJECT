using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StatsManager : MonoBehaviour {

    public static int TotalRebounds;
    public static int TotalAttempts;
    public static float TotalTime;
    int seconds;
    int minute;
    int hour;
    public Text totalattempts;
    public Text totalrebounds;
    public Text totaltime;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
       
        totalattempts.text = "" +TotalAttempts;
        totalrebounds.text = "" + TotalRebounds;

        seconds = Mathf.RoundToInt(TotalTime) % 60;
        minute = (Mathf.RoundToInt(TotalTime) / 60) % 60;
        hour = (Mathf.RoundToInt(TotalTime) / 3600) % 24;

        Debug.Log(TotalTime);
       totaltime.text = "H:" + hour + "min:" + minute + "sec:" + seconds;
	}


    void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        TotalAttempts = 0;
        TotalTime = 0f;
        TotalRebounds = 0;
    }
}
