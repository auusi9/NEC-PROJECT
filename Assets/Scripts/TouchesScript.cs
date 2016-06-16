using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TouchesScript : MonoBehaviour {

    public static int touches = 0;
    public Text touchText;
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        touchText.text = ""+touches;
    }
}
