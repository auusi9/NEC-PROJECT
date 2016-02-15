using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Button Bplay;

	// Use this for initialization
	void Start () {

        Bplay = Bplay.GetComponent<Button>();
	
	}

    public void LevelChose()
    {
        SceneManager.LoadScene("UILevels");
    }
        
	
	// Update is called once per frame
	void Update () {
	
	}
}
