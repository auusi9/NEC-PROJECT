using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Portal : MonoBehaviour {
    
    public string NextScene;
    public string CurrentScene;
    public GameObject rect;
    public GameObject Complete;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Complete.SetActive(true);
            Invoke("LoadNextLevel", 1.5f);
            rect.GetComponent<FreezeRotation>().enabled = true; 
        }
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
