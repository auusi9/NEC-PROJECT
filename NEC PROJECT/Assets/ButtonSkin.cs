using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSkin : MonoBehaviour {

  


    public void OnClick(int SkinId)
    {
        GameObject spriteChanger = GameObject.Find("SpriteChanger");

        spriteChanger.SendMessage("ChangeSprite", SkinId);
    }
	
}
