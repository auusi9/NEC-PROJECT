using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Object ChildSprite;
    public Rigidbody2D ball;
    public Vector3 ball_position;
    public Object TouchAnim;
    public Animator TouchUiAnimator;

    float actual_time;
    float invencibility = 0.0f;
    float speed;
    float volumeFX;
    bool velocity;
    bool shield;
    bool doubleBall;
    bool velocityDown;
    bool bigBall;
    bool smallBall;
    bool Die;
    bool endrotation;
    bool invulnerable;
    public float time;
    public Vector3 initialSpeed;
    Vector3 BallSize = new Vector3(1.0f, 1.0f, 1.0f);
    Animator anim;
    public GameObject trail;
    public GameObject portal;
    public AudioClip bounceAudio;
    public AudioClip GoodPowerUpSound;
    public AudioClip BadPowerUpSound;
    private AudioSource bounceSound;
    

    // Use this for initialization
    void Start ()
    {
        float volumeFX = PlayerPrefs.GetFloat("FX volume");
        ball.AddForce(new Vector3(80.0f * initialSpeed.x, 80.0f * initialSpeed.y, 0.0f));
        speed = 5.0f;
        bounceSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>(); 
        
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spikes")
        {
            
            if (shield == false)
            {
                if ((Time.time - invencibility) > 0.25f && invulnerable == false)
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
        else if (col.gameObject.tag == "Player") return;
        else
        {
            if (TouchUiAnimator.GetBool("Touched") == true)
            {
                TouchUiAnimator.Rebind();
            }
            TouchUiAnimator.SetBool("Touched",true);
            ContactPoint2D contact = col.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(TouchAnim, pos, rot);
            bounceSound.PlayOneShot(bounceAudio, volumeFX);
            TouchesScript.touches++;
            StatsManager.TotalRebounds++; 
            
        }
    }

 
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Portal")
        {
            GetComponent<Collider2D>().enabled = false;
            invulnerable = true;
            ball.velocity = Vector3.zero;
            ball.transform.SetParent(col.gameObject.transform);
            trail.SetActive(false);
            endrotation = true;
            portal = col.gameObject;
            
        }
        else if (col.gameObject.tag == "SpeedUpPowerUp")
        {
            actual_time = Time.time;
            speed = 10.0f;
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            velocity = true;
            bounceSound.PlayOneShot(BadPowerUpSound, volumeFX);
            portal.SendMessage("BonusScore", 400);
            Destroy(col.gameObject);

        }

        else if (col.gameObject.tag == "ShieldPowerUp")
        {
            shield = true;

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            bounceSound.PlayOneShot(GoodPowerUpSound, volumeFX);
            portal.SendMessage("BonusScore", -400);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "DoubleBallPowerUp")
        {
            doubleBall = true;

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            bounceSound.PlayOneShot(GoodPowerUpSound, volumeFX);
            portal.SendMessage("BonusScore", -400);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SpeedDownPowerUp")
        {
            speed = 2.0f;
            actual_time = Time.time;
            velocityDown = true;

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            bounceSound.PlayOneShot(GoodPowerUpSound, volumeFX);
            portal.SendMessage("BonusScore", -400);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "BiggerPowerUp")
        {
            actual_time = Time.time;
            BallSize = new Vector3(1.3f, 1.3f, 1.0f);
            bigBall = true;
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            bounceSound.PlayOneShot(BadPowerUpSound, volumeFX);
            portal.SendMessage("BonusScore", 400);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SmallerPowerUp")
        {
            actual_time = Time.time;
            smallBall = true;
            BallSize = new Vector3(0.7f, 0.7f, 1.0f);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            bounceSound.PlayOneShot(GoodPowerUpSound, volumeFX);
            portal.SendMessage("BonusScore", -400);
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

        if (endrotation == true)
        {
            transform.RotateAround(portal.transform.position, Vector3.forward, 8.0f);
            ball.velocity = portal.transform.position - ball.transform.position;
            ball.velocity = ball.velocity * 2.0f;
            if (BallSize.x < 0)
            {
                ball.transform.localScale = Vector3.zero;
            }
            else
            {
                BallSize = BallSize - new Vector3(0.01f, 0.01f, 0.01f);
                ball.transform.localScale = BallSize;
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
        BallSize = clone.BallSize;
    }

    void DieAnimation()
    {
            anim.SetBool("Die", true);
            ball.velocity = Vector3.zero;
            Destroy(ChildSprite);
            Destroy(GetComponent<Sprite>());
    }

}
