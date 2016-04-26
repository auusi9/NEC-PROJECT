using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class Portal : MonoBehaviour {
    
    public string NextScene;
    public string CurrentScene;
    public GameObject rect;
    public GameObject Complete;
    public Text Score;
    GameObject[] fragments;
    int LevelScore;
    int[] ifragment = null;

    void Awake()
    {
        
        fragments = GameObject.FindGameObjectsWithTag("Fragment");
        ifragment = new int[fragments.Length];
        for (int i = 0; i < fragments.Length ;i++)
        {
            ifragment[i] = 0;
            if (PlayerPrefs.GetInt(CurrentScene + "Fragment" + i) == 1)
            {
                fragments[i].SetActive(false);
            }
            
        }

    }
    void Start()
    {
     

        if (PlayerPrefs.HasKey(CurrentScene + "touches") == false)
            PlayerPrefs.SetInt(CurrentScene + "touches", 1000000);

        PlayerPrefs.SetInt(CurrentScene + "attempts", PlayerPrefs.GetInt(CurrentScene + "attempts")+1);
        PlayerPrefs.SetInt("TotalAttempts", StatsManager.TotalAttempts);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            foreach (GameObject r in GameObject.FindGameObjectsWithTag("Square"))
            {
                r.GetComponent<FreezeRotation>().enabled = true;
            }
            
            Invoke("FinishLevel", 0.7f);
            Invoke("LoadComplete", 1.7f);
            //Invoke("LoadNextLevel", 3.0f);
            
           
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

    void TryAgain()
    {
        TouchesScript.touches = 0;
        SceneManager.LoadScene(CurrentScene);
    }

    void MainMenu()
    {
        TouchesScript.touches = 0;
        SceneManager.LoadScene("LevelMenu");
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

    void FinishLevel()
    {
        StatsManager.TotalTime += Time.timeSinceLevelLoad;
        if (PlayerPrefs.HasKey(CurrentScene + "Done") == false)
        {
            PlayerPrefs.SetInt(CurrentScene + "Done", 1);
            StatsManager.TotalLevels++;
        }

        PlayerPrefs.SetInt("TotalLevels", StatsManager.TotalLevels);
        PlayerPrefs.SetFloat("TotalTime", StatsManager.TotalTime);
        PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
        if(PlayerPrefs.GetInt(CurrentScene + "touches") > TouchesScript.touches)
            PlayerPrefs.SetInt(CurrentScene + "touches", TouchesScript.touches);
        //rect.GetComponent<FreezeRotation>().enabled = true;

        for(int i= 0; i< fragments.Length;i++)
        {
            if(ifragment[i] ==1)
            {
                PlayerPrefs.SetInt(CurrentScene + "Fragment" + i, 1);
                StatsManager.TotalFragments++;
                PlayerPrefs.SetInt("TotalFragments", StatsManager.TotalFragments);
            }
        }


        PlayerPrefs.SetInt(NextScene, 1);
        CalculateScore();
        Debug.Log(LevelScore);

    }

    public void FragmentDestroyed (GameObject fragment)
    {
        for (int i = 0; i < fragments.Length; i++)
        {
            if (fragment == fragments[i])
                ifragment[i] = 1;
        }  
    }
}
