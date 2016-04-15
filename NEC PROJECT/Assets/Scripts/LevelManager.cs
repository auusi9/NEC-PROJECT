using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static int world;
    public GameObject world1_button;
    public GameObject world2_button;
    public GameObject world3_button;
    public GameObject world4_button;
    public GameObject world5_button;

    public GameObject locked1;
    public GameObject locked2;
    public GameObject locked3;
    public GameObject locked4;
    public GameObject locked5;

    public  GameObject[] background;

    public Rigidbody2D MoveCamera;

    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.SetInt("NECSCENE", 1);
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
                CheckLockedWorld1();
                break;
            case 2:
                world2_button.SetActive(true);
                world3_button.SetActive(false);
                world1_button.SetActive(false);
                CheckLockedWorld2();
                break;
            case 3:
                world3_button.SetActive(true);
                world2_button.SetActive(false);
                world4_button.SetActive(false);
                CheckLockedWorld3();
                break;
            case 4:
                world4_button.SetActive(true);
                world3_button.SetActive(false);
                world5_button.SetActive(false);
                CheckLockedWorld4();
                break;
            case 5:
                world5_button.SetActive(true);
                world1_button.SetActive(false);
                world4_button.SetActive(false);
                CheckLockedWorld5();
                break;
        }


    }
    void ChangeWorldRight()
    {
        int lastworld = world - 1;
        world++;
        if (world == 6) world = 1;
        MoveCamera.transform.position = new Vector3(-13.87f, 0);
        MoveCamera.velocity = new Vector2(8.5f, 0);
        
        foreach(GameObject r in background)
        {
            if (r == background[world-1])
            {
                r.SetActive(true);
                r.transform.position = new Vector3(0, 0, 0);
            }
            else if (r == background[lastworld])
            {
                r.transform.position = new Vector3(-15, 0, 0);
            }
            else r.SetActive(false);
        }
        
        
    }
    void ChangeWorldLeft()
    {
        int lastworld = world - 1;
        world--;
        if (world == 0) world = 5;
        MoveCamera.transform.position = new Vector3(13.87f, 0);
        MoveCamera.velocity = new Vector2(-8.5f, 0);

        foreach (GameObject r in background)
        {
            if (r == background[world - 1])
            {
                r.SetActive(true);
                r.transform.position = new Vector3(0, 0, 0);
            }
            else if (r == background[lastworld])
            {
                r.transform.position = new Vector3(15, 0, 0);
            }
            else r.SetActive(false);
        }

    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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

    void CheckLockedWorld1()
    {
        if (PlayerPrefs.GetInt("NECSCENE") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE2") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE3") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE4") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE5") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }

    void CheckLockedWorld2()
    {
        if (PlayerPrefs.GetInt("NECSCENE6") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE7") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE8") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE9") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE10") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }

    void CheckLockedWorld3()
    {
        if (PlayerPrefs.GetInt("NECSCENE11") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE12") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE13") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE14") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE15") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }

    void CheckLockedWorld4()
    {
        if (PlayerPrefs.GetInt("NECSCENE16") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE17") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE18") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE19") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE20") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }

    void CheckLockedWorld5()
    {
        if (PlayerPrefs.GetInt("NECSCENE21") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE22") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE23") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE24") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE25") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }

}
