using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelsManager : MonoBehaviour {

    public Button lvl1;

    // Use this for initialization
    void Start()
    {

        lvl1 = lvl1.GetComponent<Button>();

    }

    public void LevelChose()
    {
        SceneManager.LoadScene("NECSCENE");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
