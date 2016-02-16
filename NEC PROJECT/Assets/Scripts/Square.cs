using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Square : MonoBehaviour {

    public Rigidbody2D square;
    float angle = 1.0f;
    float prev_rotation;
    private Vector2 centerPoint;

    // Use this for initialization
    void Start () 
    {
        Input.simulateMouseWithTouches = true;
    }
	
	// Update is called once per frame
	void Update () 
    {
        float rotation = square.rotation;

        /*

        Vector2 fingermovement =  Input.GetTouch(0).deltaPosition;

        if (fingermovement.x < 0)
        {
            square.MoveRotation(rotation + angle);

        }
        else if (fingermovement.x > 0)
        {

            square.MoveRotation(rotation - angle);

        }*/
        

        
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

