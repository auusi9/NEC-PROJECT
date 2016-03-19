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
            Invoke("LoadComplete", 1.7f);
            Invoke("LoadNextLevel", 3.0f);
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

    void LoadComplete()
    {
        Complete.SetActive(true);
    }
}
