using UnityEngine;
using System.Collections;

public class Appear : MonoBehaviour {

    float a = 0.1f;
	// Use this for initialization
	void Start () {

        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (a == 1) return;
        a += 0.005f;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, a);
        

    }
}
