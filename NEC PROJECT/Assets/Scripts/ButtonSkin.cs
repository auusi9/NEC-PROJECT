using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkin : MonoBehaviour {

    public Sprite MH;
    public Sprite football;
    public Sprite pixel;
    public Sprite Eightball;
    public Sprite Bowling;
    public Sprite Eye;
    public Sprite Tennis;
    public Sprite Mouth;
    public Sprite Blue;
    public Sprite Orange;
    public Sprite Pink;
    public Sprite Skull;
    int id;
    Sprite currentsprite = null;
    public GameObject[] SkinButtons;
    void Start()
    {
        for( id = 1; id < 13; id++)
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
                    currentsprite = Eightball;
                    price = 5;
                    break;
                case 5:
                    currentsprite = Bowling;
                    price = 5;
                    break;
                case 6:
                    currentsprite = Eye;
                    price = 5;
                    break;
                case 7:
                    currentsprite = Tennis;
                    price = 5;
                    break;
                case 8:
                    currentsprite = Mouth;
                    price = 5;
                    break;
                case 9:
                    currentsprite = Blue;
                    price = 1;
                    break;
                case 10:
                    currentsprite = Orange;
                    price = 1;
                    break;
                case 11:
                    currentsprite = Pink;
                    price = 1;
                    break;
                case 12:
                    currentsprite = Skull;
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
                currentsprite = Eightball;
        
                break;
            case 5:
                currentsprite = Bowling;
         
                break;
            case 6:
                currentsprite = Eye;
            
                break;
            case 7:
                currentsprite = Tennis;
    
                break;
            case 8:
                currentsprite = Mouth;
    
                break;
            case 9:
                currentsprite = Blue;
     
                break;
            case 10:
                currentsprite = Orange;
        
                break;
            case 11:
                currentsprite = Pink;
       
                break;
            case 12:
                currentsprite = Skull;
                break;
        }
    }
}
