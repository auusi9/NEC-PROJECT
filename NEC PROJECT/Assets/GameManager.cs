using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<Scene> Scenes;
    List<Scene> AvailableScene;

    void Awake()
    { 
            DontDestroyOnLoad(gameObject);
    }


    void Start () {
     /*   
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE2"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE3"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE4"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE5"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE6"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE7"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE8"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE9"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE10"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE11"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE12"));
        Scenes.Add(SceneManager.GetSceneByName("NECSCENE13"));
       */
      
    }
	
	
}
