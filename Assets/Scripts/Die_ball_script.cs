using UnityEngine;
using System.Collections;

public class Die_ball_script : StateMachineBehaviour {
    
	 override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
