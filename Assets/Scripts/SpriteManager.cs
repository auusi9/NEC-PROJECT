﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpriteManager : MonoBehaviour {

    public Sprite Default;
    public Sprite Second;
    public Sprite Third;
    public Sprite Forth;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;
    public Sprite Eight;
    public Sprite Nine;
    public Sprite Ten;
    public Sprite Eleven;
    public Sprite Twelve;
    public Sprite Thirteen;
    public static Sprite CurrentSprite;
    public static SpriteManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

       
        switch (PlayerPrefs.GetInt("SpriteSelected"))
        {
            case 0: CurrentSprite = Default;
                break;
            case 1: CurrentSprite = Second;
                break;
            case 2: CurrentSprite = Third;
                break;
            case 3: CurrentSprite = Forth;
                break;
            case 4: CurrentSprite = Five;
                break;
            case 5: CurrentSprite = Six;
                break;
            case 6:
                CurrentSprite = Seven;
                break;
            case 7:
                CurrentSprite = Eight;
                break;
            case 8:
                CurrentSprite = Nine;
                break;
            case 9:
                CurrentSprite = Ten;
                break;
            case 10:
                CurrentSprite = Eleven;
                break;
            case 11:
                CurrentSprite = Twelve;
                break;
            case 12:
                CurrentSprite = Thirteen;
                break;
        }
    }


	void LoadSprite(GameObject r)
    {
        r.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
        r.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }

    void LoadSpriteMenu(GameObject r)
    {
        r.GetComponent<SpriteRenderer>().sprite = CurrentSprite;
    }
    public void ChangeSprite(int spriteind)
    {
        switch (spriteind)
        {
            case 0: CurrentSprite = Default;
                break;
            case 1: CurrentSprite = Second;
                break;
            case 2: CurrentSprite = Third;
                break;
            case 3: CurrentSprite = Forth;
                break;
            case 4: CurrentSprite = Five;
                break;
            case 5: CurrentSprite = Six;
                break;
            case 6:
                CurrentSprite = Seven;
                break;
            case 7:
                CurrentSprite = Eight;
                break;
            case 8:
                CurrentSprite = Nine;
                break;
            case 9:
                CurrentSprite = Ten;
                break;
            case 10:
                CurrentSprite = Eleven;
                break;
            case 11:
                CurrentSprite = Twelve;
                break;
            case 12:
                CurrentSprite = Thirteen;
                break;

        }
        PlayerPrefs.SetInt("SpriteSelected", spriteind);
    }
}
