using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour {

    public AudioClip MenuMusic;
    public AudioClip GameplayMusic;
    public AudioClip GameplayMusic2;
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
        StatsManager.TotalScore = PlayerPrefs.GetInt("TotalScore");
        StatsManager.TotalLevels = PlayerPrefs.GetInt("TotalLevels");
        StatsManager.TotalFragments = PlayerPrefs.GetInt("TotalFragments");

        if (PlayerPrefs.HasKey("Music volume") == false)
        {
            PlayerPrefs.SetFloat("Music volume",0.5f);
        }

        if (PlayerPrefs.HasKey("FX volume") == false)
        {
            PlayerPrefs.SetFloat("FX volume", 1);
        }

        if (PlayerPrefs.HasKey("Music volume"))
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music volume");
    }

    void FixedUpdate()
    {
       if(SceneManager.GetActiveScene().buildIndex == 5)
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music volume");

        if (SceneManager.GetActiveScene().buildIndex != currentscene)
        {
            if (SceneManager.GetActiveScene().buildIndex < 8 && currentscene >= 8)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = MenuMusic;
                GetComponent<AudioSource>().Play();
            }
            else if (SceneManager.GetActiveScene().buildIndex >= 33 && currentscene < 33)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = GameplayMusic2;
                GetComponent<AudioSource>().Play();
            }
            else if (SceneManager.GetActiveScene().buildIndex >= 8 && currentscene < 8)
            {
                GetComponent<AudioSource>().Stop();
                GetComponent<AudioSource>().clip = GameplayMusic;
                GetComponent<AudioSource>().Play();
            }
             
            currentscene = SceneManager.GetActiveScene().buildIndex;
        }
    }


}
