using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Square : MonoBehaviour {

    public Rigidbody2D square;
    float angle = 1.0f;
    float prev_rotation;
    

    // Use this for initialization
    void Start () 
    {
        
    }
	
	// Update is called once per frame
	void Update () 
    {



        float rotation = square.rotation;

        if (Input.GetButton("Fire1"))
        {
            square.MoveRotation(rotation + angle);
        }
        else if (Input.GetButton("Fire2"))
        {
            square.MoveRotation(rotation - angle);
        }





        if (Input.touchCount > 0)
        {
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];

            
           float rotate = square.rotation;


            Vector2 fingerposition =  myTouch.position;

            Vector2 fingermovement = myTouch.deltaPosition;

            Vector2 position2 = fingerposition - fingermovement;

           if(fingermovement.magnitude > 0) {square.MoveRotation(rotate + Vector2.Angle(fingerposition, position2)); }
           else square.MoveRotation(rotate - Vector2.Angle(fingerposition, position2));






            /*





                        if (myTouch.position.y > Screen.height / 2)
                        {

                            if (fingermovement.x < 0)
                            {
                                square.MoveRotation(rotate + (fingermovement.magnitude / 5));
                            }
                            else
                            {
                                square.MoveRotation(rotate - (fingermovement.magnitude / 5));
                            }
                        }
                        else
                        {

                            if (fingermovement.x < 0)
                            {
                                square.MoveRotation(rotate - (fingermovement.magnitude / 5));
                            }
                            else
                            {
                                square.MoveRotation(rotate + (fingermovement.magnitude / 5));
                            }
                        }*/
        }

    }

}

