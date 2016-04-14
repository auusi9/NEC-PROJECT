using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class AboutUs : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnWebsite()
    {
        Application.OpenURL("http://nyacu.github.io/NEC/");
    }

    public void OnTwitter()
    {
        Application.OpenURL("https://twitter.com/NyacuGames");
    }

    public void OnFacebook()
    {
        Application.OpenURL("https://www.facebook.com/NyacuGames/");
    }

    public void  OnMusic()
    {
        Application.OpenURL("https://soundcloud.com/user-158205542");
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void OnAboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }
    void OnCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
