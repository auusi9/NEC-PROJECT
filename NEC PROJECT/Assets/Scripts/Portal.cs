using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour {
    
    public string NextScene;
    public string CurrentScene;
    public GameObject rect;
    public GameObject Complete;
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
            PlayerPrefs.SetFloat("TotalTime", StatsManager.TotalTime);
            PlayerPrefs.SetInt("TotalRebounds", StatsManager.TotalRebounds);
            rect.GetComponent<FreezeRotation>().enabled = true;
            PlayerPrefs.SetInt(NextScene, 1);
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
}
