using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip MenuMusic;
    public AudioClip GameplayMusic;
    public static MusicManager instance;

    int currentscene = 0;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        StatsManager.TotalAttempts = PlayerPrefs.GetInt("TotalAttempts");
        StatsManager.TotalRebounds = PlayerPrefs.GetInt("TotalRebounds");
        StatsManager.TotalTime = PlayerPrefs.GetFloat("TotalTime");
    }

    void FixedUpdate()
    {
        
        if (SceneManager.GetActiveScene().buildIndex != currentscene)
        {
            if (SceneManager.GetActiveScene().buildIndex < 2 && currentscene >= 2)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MenuMusic;
                GetComponent<AudioSource>().Play();
            }
            else if (SceneManager.GetActiveScene().buildIndex >= 2 && currentscene < 2)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = GameplayMusic;
                GetComponent<AudioSource>().Play();
            }
           
            currentscene = SceneManager.GetActiveScene().buildIndex;
        }
    }

}
