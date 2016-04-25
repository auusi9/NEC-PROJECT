using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuStats : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadGlobalStats()
    {
        FXManager.instance.PlayUIClick();
        SceneManager.LoadScene("StatsScene");
    }

    public void LoadLevelStats()
    {
        FXManager.instance.PlayUIClick();
        SceneManager.LoadScene("LevelStats");
    }

    public void MainMenu()
    {
        FXManager.instance.PlayUIClickBack();
        SceneManager.LoadScene("MainMenu");
    }

  

}
