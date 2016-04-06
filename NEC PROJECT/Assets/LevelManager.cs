using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour {

    int world;
    public GameObject world1_button;
    public GameObject world2_button;
    public GameObject world3_button;
    public GameObject world4_button;
    public GameObject world5_button;

    public GameObject locked;

    [System.Serializable]
    public class level
    {
        public string levelname;
        public int worldnumber;
        public int unlocked;
        public bool interactable;

        public Button.ButtonClickedEvent OnClickEvent;

    }
    public List<level> levelList;

	// Use this for initialization
	void Start ()
    {
        
        world = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void FixedUpdate()
    {
        switch (world)
        {
            case 1:
                world1_button.SetActive(true);
                world2_button.SetActive(false);
                world5_button.SetActive(false);
                break;
            case 2:
                world2_button.SetActive(true);
                world3_button.SetActive(false);
                world1_button.SetActive(false);
                break;
            case 3:
                world3_button.SetActive(true);
                world2_button.SetActive(false);
                world4_button.SetActive(false);
                break;
            case 4:
                world4_button.SetActive(true);
                world3_button.SetActive(false);
                world5_button.SetActive(false);
                break;
            case 5:
                world5_button.SetActive(true);
                world1_button.SetActive(false);
                world4_button.SetActive(false);
                break;
        }


    }
    void ChangeWorldRight()
    {
        world++;
        if (world == 6) world = 1;
    }
    void ChangeWorldLeft()
    {
        world--;
        if (world == 0) world = 5;
    }
    void LoadLevel1()
    {
        switch (world)
        {
            case 1:
                SceneManager.LoadScene("NECSCENE");
                break;
            case 2:
                if(PlayerPrefs.GetInt("NECSCENE6") == 1)
                {
                SceneManager.LoadScene("NECSCENE6");
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("NECSCENE11") == 1)
                {
                    SceneManager.LoadScene("NECSCENE11");
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("NECSCENE16") == 1)
                {
                    SceneManager.LoadScene("NECSCENE16");
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("NECSCENE21") == 1)
                {
                    SceneManager.LoadScene("NECSCENE21");
                }
                break;
        }
    }
    void LoadLevel2()
    {
        switch (world)
        {
            case 1:
                if (PlayerPrefs.GetInt("NECSCENE2") == 1)
                {
                    SceneManager.LoadScene("NECSCENE2");
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("NECSCENE7") == 1)
                {
                    SceneManager.LoadScene("NECSCENE7");
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("NECSCENE12") == 1)
                {
                    SceneManager.LoadScene("NECSCENE12");
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("NECSCENE17") == 1)
                {
                    SceneManager.LoadScene("NECSCENE17");
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("NECSCENE22") == 1)
                {
                    SceneManager.LoadScene("NECSCENE22");
                }
                break;
        }
    }
    void LoadLevel3()
    {
        switch (world)
        {
            case 1:
                if (PlayerPrefs.GetInt("NECSCENE3") == 1)
                {
                    SceneManager.LoadScene("NECSCENE3");
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("NECSCENE8") == 1)
                {
                    SceneManager.LoadScene("NECSCENE8");
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("NECSCENE13") == 1)
                {
                    SceneManager.LoadScene("NECSCENE13");
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("NECSCENE18") == 1)
                {
                    SceneManager.LoadScene("NECSCENE18");
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("NECSCENE23") == 1)
                {
                    SceneManager.LoadScene("NECSCENE23");
                }
                break;
        }
    }
    void LoadLevel4()
    {
        switch (world)
        {
            case 1:
                if (PlayerPrefs.GetInt("NECSCENE4") == 1)
                {
                    SceneManager.LoadScene("NECSCENE4");
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("NECSCENE9") == 1)
                {
                    SceneManager.LoadScene("NECSCENE9");
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("NECSCENE14") == 1)
                {
                    SceneManager.LoadScene("NECSCENE14");
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("NECSCENE19") == 1)
                {
                    SceneManager.LoadScene("NECSCENE19");
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("NECSCENE24") == 1)
                {
                    SceneManager.LoadScene("NECSCENE24");
                }
                break;
        }
    }
    void LoadLevel5()
    {
        switch (world)
        {
            case 1:
                if (PlayerPrefs.GetInt("NECSCENE5") == 1)
                {
                    SceneManager.LoadScene("NECSCENE5");
                }
                break;
            case 2:
                if (PlayerPrefs.GetInt("NECSCENE10") == 1)
                {
                    SceneManager.LoadScene("NECSCENE10");
                }
                break;
            case 3:
                if (PlayerPrefs.GetInt("NECSCENE15") == 1)
                {
                    SceneManager.LoadScene("NECSCENE15");
                }
                break;
            case 4:
                if (PlayerPrefs.GetInt("NECSCENE20") == 1)
                {
                    SceneManager.LoadScene("NECSCENE20");
                }
                break;
            case 5:
                if (PlayerPrefs.GetInt("NECSCENE25") == 1)
                {
                    SceneManager.LoadScene("NECSCENE25");
                }
                break;
        }
    }
 
}
