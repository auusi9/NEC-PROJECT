using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Die_ball_script : StateMachineBehaviour {
    public string CurrentScene;
	 override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
           
            SceneManager.LoadScene(CurrentScene);
        }
        Destroy(animator.gameObject);
    }
}
