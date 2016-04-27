using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkin : MonoBehaviour {

    public Sprite MH;
    public Sprite football;
    public Sprite pixel;
    int id;
    Sprite currentsprite;
    public GameObject[] SkinButtons;
    void Start()
    {
        for( id = 0; id< 4; id++)
        {
            if (PlayerPrefs.GetInt("Skin" + id) == 1)
            {
                CurrentSprite();
                SkinButtons[id].GetComponent<Image>().sprite = currentsprite;

            }
            
        }
    }



    public void OnClick(int SkinId)
    {
        id = SkinId;
        if (PlayerPrefs.GetInt("Skin" + SkinId) == 1)
        {
            GameObject spriteChanger = GameObject.Find("SpriteChanger");

            spriteChanger.SendMessage("ChangeSprite", SkinId);
            
        }
        else
        {
            int price = 0;
            switch(SkinId)
            {
                case 1:
                    price = 5;
                    currentsprite = MH;
                    break;
                case 2:
                    price = 5;
                    currentsprite = football;
                    break;
                case 3:
                    price = 5;
                    currentsprite = pixel;
                    break;
                case 4:
                    price = 5;
                    break;
                case 5:
                    price = 5;
                    break;
            }
            if(price <= StatsManager.TotalFragments)
            {
                
                PlayerPrefs.SetInt("Skin" + SkinId, 1);
                StatsManager.TotalFragments -= price;
                PlayerPrefs.SetInt("TotalFragments", StatsManager.TotalFragments);
              
                    CurrentSprite();

                SkinButtons[id].GetComponent<Image>().sprite = currentsprite;
            }
        }
        
    }

    void CurrentSprite()
    {
        switch (id)
        {
            case 0: currentsprite = SkinButtons[id].GetComponent<Image>().sprite;  break;
            case 1: 
                currentsprite = MH;
                break;
            case 2: 
                currentsprite = football;
                break;
            case 3: 
                currentsprite = pixel;
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }
}
