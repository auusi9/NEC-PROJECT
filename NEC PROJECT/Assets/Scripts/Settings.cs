using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Settings : MonoBehaviour {

    public Slider guislider;
    public Slider guislider2;

	// Use this for initialization
	void Start () {

        guislider.value = PlayerPrefs.GetFloat("Music volume");
        guislider2.value = PlayerPrefs.GetFloat("FX volume");
	}
	
	// Update is called once per frame
	void Update () 
    {
        PlayerPrefs.SetFloat("Music volume", guislider.value);
        PlayerPrefs.SetFloat("FX volume", guislider2.value);

        Debug.Log(guislider.value);
	}

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
