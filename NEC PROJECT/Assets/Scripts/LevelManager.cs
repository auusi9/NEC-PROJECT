using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public static int world;
    public Text WorldText;

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

    void FixedUpdate()
    {
        switch (world)
        {
            case 1:
                WorldText.text = "I";
                 CheckLockedWorld1();
                break;
            case 2:
                WorldText.text = "II";
                CheckLockedWorld2();
                break;
            case 3:
                WorldText.text = "III";
                CheckLockedWorld3();
                break;
            case 4:
                WorldText.text = "IV";
                CheckLockedWorld4();
                break;
            case 5:
                WorldText.text = "V";
                CheckLockedWorld5();
                break;
            case 6:
                WorldText.text = "VI";
                CheckLockedWorld6();
                break;
            case 7:
                WorldText.text = "VII";
                CheckLockedWorld7();
                break;
            case 8:
                WorldText.text = "VIII";
                CheckLockedWorld8();
                break;
            case 9:
                WorldText.text = "IX";
                CheckLockedWorld9();
                break;
            case 10:
                WorldText.text = "X";
                CheckLockedWorld10();
                break;
        }


    }
    void ChangeWorldRight()
    {
        int lastworld = world - 1;
        world++;
        if (world == 11) world = 1;
        MoveCamera.transform.position = new Vector3(-13.87f, 0);
        MoveCamera.velocity = new Vector2(23.5f, 0);
       
            foreach (GameObject r in background)
            {
                if (r == background[world - 1])
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
        if (world == 0) world = 10;
        MoveCamera.transform.position = new Vector3(13.87f, 0);
        MoveCamera.velocity = new Vector2(-23.5f, 0);

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
        FXManager.instance.PlayUIClickBack();
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
            case 6:
                if (PlayerPrefs.GetInt("NECSCENE26") == 1)
                {
                    SceneManager.LoadScene("NECSCENE26");
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("NECSCENE31") == 1)
                {
                    SceneManager.LoadScene("NECSCENE31");
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("NECSCENE36") == 1)
                {
                    SceneManager.LoadScene("NECSCENE36");
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("NECSCENE41") == 1)
                {
                    SceneManager.LoadScene("NECSCENE41");
                }
                break;
            case 10:
                if (PlayerPrefs.GetInt("NECSCENE46") == 1)
                {
                    SceneManager.LoadScene("NECSCENE46");
                }
                break;
        }
        FXManager.instance.PlayUIClick();
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
            case 6:
                if (PlayerPrefs.GetInt("NECSCENE27") == 1)
                {
                    SceneManager.LoadScene("NECSCENE27");
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("NECSCENE32") == 1)
                {
                    SceneManager.LoadScene("NECSCENE32");
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("NECSCENE37") == 1)
                {
                    SceneManager.LoadScene("NECSCENE37");
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("NECSCENE42") == 1)
                {
                    SceneManager.LoadScene("NECSCENE42");
                }
                break;
            case 10:
                if (PlayerPrefs.GetInt("NECSCENE47") == 1)
                {
                    SceneManager.LoadScene("NECSCENE47");
                }
                break;
        }
        FXManager.instance.PlayUIClick();
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
            case 6:
                if (PlayerPrefs.GetInt("NECSCENE28") == 1)
                {
                    SceneManager.LoadScene("NECSCENE28");
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("NECSCENE33") == 1)
                {
                    SceneManager.LoadScene("NECSCENE33");
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("NECSCENE38") == 1)
                {
                    SceneManager.LoadScene("NECSCENE38");
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("NECSCENE43") == 1)
                {
                    SceneManager.LoadScene("NECSCENE43");
                }
                break;
            case 10:
                if (PlayerPrefs.GetInt("NECSCENE48") == 1)
                {
                    SceneManager.LoadScene("NECSCENE48");
                }
                break;
        }
        FXManager.instance.PlayUIClick();
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
            case 6:
                if (PlayerPrefs.GetInt("NECSCENE29") == 1)
                {
                    SceneManager.LoadScene("NECSCENE29");
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("NECSCENE34") == 1)
                {
                    SceneManager.LoadScene("NECSCENE34");
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("NECSCENE39") == 1)
                {
                    SceneManager.LoadScene("NECSCENE39");
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("NECSCENE44") == 1)
                {
                    SceneManager.LoadScene("NECSCENE44");
                }
                break;
            case 10:
                if (PlayerPrefs.GetInt("NECSCENE49") == 1)
                {
                    SceneManager.LoadScene("NECSCENE49");
                }
                break;
        }
        FXManager.instance.PlayUIClick();
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
            case 6:
                if (PlayerPrefs.GetInt("NECSCENE30") == 1)
                {
                    SceneManager.LoadScene("NECSCENE30");
                }
                break;
            case 7:
                if (PlayerPrefs.GetInt("NECSCENE35") == 1)
                {
                    SceneManager.LoadScene("NECSCENE35");
                }
                break;
            case 8:
                if (PlayerPrefs.GetInt("NECSCENE40") == 1)
                {
                    SceneManager.LoadScene("NECSCENE40");
                }
                break;
            case 9:
                if (PlayerPrefs.GetInt("NECSCENE45") == 1)
                {
                    SceneManager.LoadScene("NECSCENE45");
                }
                break;
            case 10:
                if (PlayerPrefs.GetInt("NECSCENE50") == 1)
                {
                    SceneManager.LoadScene("NECSCENE50");
                }
                break;
        }
        FXManager.instance.PlayUIClick();
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
    void CheckLockedWorld6()
    {
        if (PlayerPrefs.GetInt("NECSCENE26") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE27") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE28") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE29") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE30") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }

    void CheckLockedWorld7()
    {
        if (PlayerPrefs.GetInt("NECSCENE31") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE32") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE33") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE34") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE35") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }
    void CheckLockedWorld8()
    {
        if (PlayerPrefs.GetInt("NECSCENE36") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE37") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE38") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE39") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE40") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }
    void CheckLockedWorld9()
    {
        if (PlayerPrefs.GetInt("NECSCENE41") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE42") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE43") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE44") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE45") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }
    void CheckLockedWorld10()
    {
        if (PlayerPrefs.GetInt("NECSCENE46") == 1)
        {
            locked1.SetActive(false);
        }
        else locked1.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE47") == 1)
        {
            locked2.SetActive(false);
        }
        else locked2.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE48") == 1)
        {
            locked3.SetActive(false);
        }
        else locked3.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE49") == 1)
        {
            locked4.SetActive(false);
        }
        else locked4.SetActive(true);
        if (PlayerPrefs.GetInt("NECSCENE50") == 1)
        {
            locked5.SetActive(false);
        }
        else locked5.SetActive(true);
    }
}
