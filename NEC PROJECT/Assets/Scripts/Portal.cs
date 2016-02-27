using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour {
    

    public string NextScene;
    public string CurrentScene;
    
	// Use this for initialization
	void Start () 
    {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            
            Invoke("LoadNextLevel", 2);
        }

    }




        // Update is called once per frame
        void Update () 
    {
        
    }

    

    void LateUpdate()
    {

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {

            SceneManager.LoadScene(CurrentScene);
        }

    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(NextScene);
    }
}
