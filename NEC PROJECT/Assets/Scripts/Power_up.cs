using UnityEngine;
using System.Collections;

public class Power_up : MonoBehaviour {

    public CircleCollider2D ball;
    public PolygonCollider2D power_up_speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(power_up_speed.IsTouching(ball))
        {
            Destroy(gameObject, 0.05f);
        }
	}
}
