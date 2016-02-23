using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelsManager : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("NECSCENE");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("NECSCENE2");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("NECSCENE3");
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene("NECSCENE4");
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
