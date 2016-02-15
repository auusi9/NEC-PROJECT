using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

    public Rigidbody2D square;
    float angle = 1.0f;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        float rotation = square.rotation;
        if(Input.GetButton("Fire1"))
        {
            square.MoveRotation(rotation + angle);
        }
        else if(Input.GetButton("Fire2"))
        {
            square.MoveRotation(rotation - angle);
        }
	}
}
