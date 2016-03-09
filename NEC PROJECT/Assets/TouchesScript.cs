using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchesScript : MonoBehaviour {

    public static int touches = 0;
    public Text touchText;
    // Use this for initialization
    void Start () {

        

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        touchText.text = "Touches : " + touches;
    }
}
