using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour {
    

    public string NextScene;
    public string CurrentScene;
    public GameObject rect;
    
    
	// Use this for initialization
	void Start () 
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
           
            Invoke("LoadNextLevel", 2);
            rect.GetComponent<FreezeRotation>().enabled = true;
            

          
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
            TouchesScript.touches = 0;
            SceneManager.LoadScene(CurrentScene);
            
        }

    }

    void LoadNextLevel()
    {
        TouchesScript.touches = 0;
        SceneManager.LoadScene(NextScene);
    }
}
