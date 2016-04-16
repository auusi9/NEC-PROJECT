using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Portal : MonoBehaviour {
    
    public string NextScene;
    public string CurrentScene;
    public GameObject rect;
    public GameObject Complete;
    public Text Score;
    int LevelScore;
    void Start()
    {
        
        StatsManager.TotalAttempts++;
        PlayerPrefs.SetInt("TotalAttempts", StatsManager.TotalAttempts);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Invoke("LoadComplete", 1.7f);
            Invoke("LoadNextLevel", 3.0f);
            
            StatsManager.TotalTime += Time.timeSinceLevelLoad;
            if(PlayerPrefs.HasKey(CurrentScene + "Done") == false)
            {
                PlayerPrefs.SetInt(CurrentScene + "Done", 1);
                StatsManager.TotalLevels++;
            }
            
            PlayerPrefs.SetInt("TotalLevels", StatsManager.TotalLevels);
            PlayerPrefs.SetFloat("TotalTime", StatsManager.TotalTime);
            PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
            rect.GetComponent<FreezeRotation>().enabled = true;
            PlayerPrefs.SetInt(NextScene, 1);
            CalculateScore();
            Debug.Log(LevelScore);
            if(StartMenu.menu != null)
                Destroy(StartMenu.menu.gameObject);
        }
    }
   
    void LateUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            TouchesScript.touches = 0;
            StartMenu.menu.gameObject.SetActive(true);
            StatsManager.TotalTime += Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat("TotalTime", StatsManager.TotalTime );
            PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
            Time.timeScale = 0f;
            SceneManager.LoadScene(CurrentScene);
        }
       
        
    }

    void LoadNextLevel()
    {
        TouchesScript.touches = 0;
        SceneManager.LoadScene(NextScene);
    }

    void LoadComplete()
    {
        Complete.SetActive(true);
    }
    void CalculateScore()
    {
        int penalization = 50;
        int totalpenalization = 0;
        int j = 0;
        for (int i = 0; i < TouchesScript.touches; i++)
        {
            if (i - j == 2)
            {
                if (penalization != 6) penalization--;
                totalpenalization = totalpenalization - penalization;
                j = i;
            }
            else totalpenalization -= penalization;
        }
        
       
        j = 0;
        penalization = 18;
        for (int i = 0; i < (Time.timeSinceLevelLoad*10); i++)
        {
            if (i - j == 30)
            {
                if (penalization != 6) penalization--;
                totalpenalization = totalpenalization - penalization;
                j = i;
            }
            else totalpenalization -= penalization ;
        }
        Debug.Log("Total Penalty: " + totalpenalization);
        Debug.Log("Time: " + Time.timeSinceLevelLoad);
        LevelScore = LevelScore + totalpenalization + 10000;

        if(LevelScore < 0)
        {
            LevelScore = 0;
        }
        Score.text = "" + LevelScore;
        Debug.Log(PlayerPrefs.GetInt(CurrentScene + "Score"));
        if (LevelScore > PlayerPrefs.GetInt(CurrentScene + "Score"))
        {
            
            StatsManager.TotalScore += (LevelScore - PlayerPrefs.GetInt(CurrentScene + "Score"));
            PlayerPrefs.SetInt(CurrentScene + "Score", LevelScore);
            PlayerPrefs.SetInt("TotalScore", StatsManager.TotalScore);
            Debug.Log(StatsManager.TotalScore);
        }
    }

    void BonusScore(int bonus)
    {
        LevelScore += bonus;
        Debug.Log("Bonus:" + bonus);
    }
}
