using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Object ChildSprite;
    public string LevelName;
    public Rigidbody2D ball;
    public Vector3 ball_position;
    float actual_time;
    float invencibility = 0.0f;
    float speed;
    bool velocity;
    bool shield;
    bool doubleBall;
    bool velocityDown;
    bool bigBall;
    bool smallBall;
    bool Die;
    public float time;
    Vector3 BallSize;
    
    Animator anim;
    

    // Use this for initialization
    void Start () 
    {

        BallSize = new Vector3(1.0f, 1.0f, 1.0f);
        ball.AddForce(new Vector3(80.0f, 0.0f, 0.0f));
        speed = 5.0f;
        
        anim = GetComponent<Animator>();
        
	}
	
    


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spikes")
        {
            
            if (shield == false)
            {
                if ((Time.time - invencibility) > 0.25f)
                {

                    DieAnimation();
                }

            }
            else
            { 
                shield = false; anim.SetBool("Shield", false);
                invencibility = Time.time;
            }
            
            
        }
    }
  
    void OnTriggerEnter2D(Collider2D col)
    {
      
        if (col.gameObject.name == "Portal")
        {
            ball.velocity = Vector3.zero;
            SceneManager.LoadScene("Menu");
            
        }

        else if (col.gameObject.tag == "SpeedUpPowerUp")
        {
            actual_time = Time.time;
            speed = 10.0f;
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            velocity = true;
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "ShieldPowerUp")
        {
            shield = true;

            
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);
            
        }

        else if (col.gameObject.tag == "DoubleBallPowerUp")
        {


            doubleBall = true;

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SpeedDownPowerUp")
        {
            speed = 2.0f;
            actual_time = Time.time;
            velocityDown = true;

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);

        }

        else if (col.gameObject.tag == "BiggerPowerUp")
        {
            actual_time = Time.time;
            BallSize = new Vector3(1.3f, 1.3f, 1.0f);
            bigBall = true;
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SmallerPowerUp")
        {
            actual_time = Time.time;
            smallBall = true;
            BallSize = new Vector3(0.7f, 0.7f, 1.0f);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);

            Destroy(col.gameObject);            
        }

    }

    // Update is called once per frame
    void Update ()
    {
        ball.velocity = ball.velocity.normalized * speed;
        
        if(doubleBall == true)
        {

            Ball clone; 
 
            clone = Instantiate(this);
            clone.GetComponentsfrom(this);

            doubleBall = false;

        }

        if (shield == true)
        {

            anim.SetBool("Shield", true);

        }
       
       


        //Velocity PowerUp
        if (velocity == true)
        {
            
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

            gameObject.transform.localScale = BallSize;
            if ((Time.time - actual_time) > (time +2))
            {
                bigBall = false;
                BallSize = Vector3.one;
                gameObject.transform.localScale = BallSize;
            }
            
        }

        //Smaller Ball PowerUp
        if (smallBall == true)
        {
            
            gameObject.transform.localScale = BallSize;
            if ((Time.time - actual_time) > (time + 2))
            {
                smallBall = false;
                BallSize = Vector3.one;
                gameObject.transform.localScale = BallSize;
            }
            
        }
    }


    void GetComponentsfrom(Ball clone)
    {
        time = clone.time;
        actual_time = clone.actual_time;
        speed = clone.speed;
        velocity = clone.velocity;
        shield = clone.shield;
        //doubleBall = clone.doubleBall;
        velocityDown = clone.velocityDown;
        bigBall = clone.bigBall;
        smallBall = clone.smallBall;


    }


    void DieAnimation()
    {
        
            anim.SetBool("Die", true);
            ball.velocity = Vector3.zero;
            Destroy(ChildSprite);
            Destroy(GetComponent<Sprite>());

    }













}
