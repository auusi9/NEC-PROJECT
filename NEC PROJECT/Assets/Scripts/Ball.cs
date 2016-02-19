﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Object ball_clone;
    public string LevelName;
    public Rigidbody2D ball;
    public Vector3 ball_position;
    float actual_time;
    float speed;
    bool velocity;
    bool shield;
    bool doubleBall;
    bool velocityDown;
    bool bigBall;
    bool smallBall;
    public float time;
    
    Animator anim;
    

    // Use this for initialization
    void Start () 
    {

        
        ball.AddForce(new Vector3(80.0f, 0.0f, 0.0f));
        speed = 5.0f;
        
        anim = GetComponent<Animator>();
        
	}
	
    public void ResetActualScene()
    {
        SceneManager.LoadScene(LevelName);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spikes")
        {
            if (shield == false)
            {

                if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
                {

                    ResetActualScene();
                }
                Destroy(this.gameObject);

            }
            else { shield = false; anim.SetBool("Shield", false); }

        }
        else if (col.gameObject.tag == "Marks")
        {

          

        }
        


    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
      
        if (col.gameObject.name == "Portal")
        {
            ball.velocity = Vector3.zero;
            SceneManager.LoadScene("Menu");
            
        }

        else if (col.gameObject.name == "Power-up01")
        {
            actual_time = Time.time;
            velocity = true;
            Destroy(col.gameObject);
        }

        else if(col.gameObject.name == "Shield")
        {
            shield = true;
            anim.SetBool("Shield", true);

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);
            
        }

        else if(col.gameObject.name == "DoubleBall")
        {
            
            
            Instantiate(ball_clone, ball.position, ball.transform.rotation);

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);
        }

        else if(col.gameObject.name == "SpeedDown")
        {
            actual_time = Time.time;
            velocityDown = true;

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);

        }

        else if(col.gameObject.name == "Power_up_bigger")
        {
            actual_time = Time.time;
            bigBall = true;
            Destroy(col.gameObject);
        }

        else if(col.gameObject.name == "Power_up_smaller")
        {
            actual_time = Time.time;
            smallBall = true;
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();

            parent.SetBool("Die", true);
            Destroy(col.gameObject);            
        }

    }

    // Update is called once per frame
    void Update ()
    {
        ball.velocity = ball.velocity.normalized * speed;
        

        //Velocity PowerUp
        if (velocity == true)
        {
            speed = 10.0f;
            ball.AddForce(ball.velocity.normalized * speed);

            if((Time.time - actual_time) > time)
            {
                velocity = false;
                speed = 5.0f;
            }
        }
       
        //Speed Down PowerUp
        if (velocityDown == true)
        {
            speed = 2.0f;
            ball.AddForce(ball.velocity.normalized * speed);

            if ((Time.time - actual_time) > time)
            {
                velocityDown = false;
                speed = 5.0f;
            }
        }

        //Bigger Ball PowerUp
        if(bigBall == true)
        {
            gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 1.0f);
            if ((Time.time - actual_time) > (time +2))
            {
                bigBall = false;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }

        //Smaller Ball PowerUp
        if (smallBall == true)
        {
            gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
            if ((Time.time - actual_time) > (time + 2))
            {
                smallBall = false;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
