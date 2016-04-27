using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public Object ChildSprite;
    public Rigidbody2D ball;
    public Vector3 ball_position;
    public Object TouchAnim;
    public Animator TouchUiAnimator;
    public Object ShieldBreak;

    float blinktime;
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
    bool endrotation;
    bool Invisible;
    bool invulnerable;
    public float time;
    public Vector3 initialSpeed;
    Vector3 BallSize = new Vector3(1.0f, 1.0f, 1.0f);
    Animator anim;
    public GameObject trail;
    public GameObject portal;
    Color InvisibleColor;
    bool blink;
    // Use this for initialization
    void Start ()
    {
        GameObject spritemanager = GameObject.Find("SpriteChanger");
        spritemanager.SendMessage("LoadSprite", this.gameObject);

        InvisibleColor =  new Color(1f, 1f, 1f, 1f);
        ball.AddForce(new Vector3(80.0f * initialSpeed.x, 80.0f * initialSpeed.y, 0.0f));
        speed = 5.0f;
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
                    FXManager.instance.PlayDie();
                    Invisible = false;
                    speed = 0;
                    DieAnimation();
                }
            }
            else
            { 
                shield = false;
                anim.SetBool("Shield", false);        
                Instantiate(ShieldBreak,transform.position, transform.rotation);
                invencibility = Time.time;
               
            }
            GetComponent<SpriteRenderer>().sprite = null;
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
            FXManager.instance.PlayBounce();
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
            DeactivatePowerUps();
            ball.transform.SetParent(col.gameObject.transform);
            trail.SetActive(false);
            Invisible = false;
            InvisibleColor = new Color(1f, 1f, 1f, 1f);
            transform.GetChild(1).GetComponent<SpriteRenderer>().color = InvisibleColor;
            endrotation = true;
            FXManager.instance.PlayWin();
            portal = col.gameObject;
        }
        else if(col.gameObject.tag == "Random")
        {
            TakePowerUp(Mathf.RoundToInt(Random.Range(0,6.5f)));
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "SpeedUpPowerUp")
        {
            TakePowerUp(0);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "ShieldPowerUp")
        {
            TakePowerUp(1);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "DoubleBallPowerUp")
        {
            TakePowerUp(2);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SpeedDownPowerUp")
        {
            TakePowerUp(3);

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "BiggerPowerUp")
        {
            TakePowerUp(4);

            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            FXManager.instance.PlayPowerRed();
            Destroy(col.gameObject);
        }

        else if (col.gameObject.tag == "SmallerPowerUp")
        {
            TakePowerUp(5);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);            
        }
        else if (col.gameObject.tag == "Invisible")
        {
            TakePowerUp(6);
            Animator parent = col.transform.parent.gameObject.GetComponent<Animator>();
            parent.SetBool("Die", true);
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "Fragment")
        {
            portal.SendMessage("FragmentDestroyed", col.gameObject);
            for(int i  = 0; i< col.gameObject.transform.childCount; i++)
            { 
                Destroy(col.gameObject.transform.GetChild(i).gameObject);
            }
            col.gameObject.GetComponent<Animator>().SetBool("Die", true);
        }
    }


    void Update()
    {
        ball.velocity = ball.velocity.normalized * speed;
    }
    // Update is called once per frame
    void FixedUpdate ()
    {  
        if(doubleBall == true)
        {
            Ball clone; 
            clone = Instantiate(this);
            clone.GetComponentsfrom(this);
            doubleBall = false;
        }

        //ShieldAnimation
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
       
        if(Invisible == true)
        {
            if(blink)
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = InvisibleColor;
                InvisibleColor = new Color(1f, 1f, 1f, 1f);
                if ((Time.time - blinktime) > 0.1f)
                {
                    blink = false;
                    blinktime = Time.time;
                }
                    
            }
            else
            {
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = InvisibleColor;
                InvisibleColor = new Color(1f, 1f, 1f, 0f);
                if ((Time.time - blinktime) > 0.3f)
                {
                    blink = true;
                    blinktime = Time.time;
                }
            }

            if ((Time.time - actual_time) > time+2)
            {
                Invisible = false;
                InvisibleColor = new Color(1f, 1f, 1f, 1f);
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = InvisibleColor;
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
        velocityDown = clone.velocityDown;
        bigBall = clone.bigBall;
        smallBall = clone.smallBall;
        BallSize = clone.BallSize;
    }

    void DieAnimation()
    {
        GetComponent<FreezeRotation>().enabled = true;
            anim.SetBool("Die", true);
            ball.velocity = Vector3.zero;
            Destroy(ChildSprite);
            Destroy(GetComponent<Sprite>());
    }


    void DeactivatePowerUps()
    {
        smallBall = false;
        bigBall = false;
        velocity = false;
        velocityDown = false;
    }

    void TakePowerUp(int id)
    {
        switch(id)
        {
            case 0:
                velocity = true;
                actual_time = Time.time;
                speed = 10.0f;
                portal.SendMessage("BonusScore", 400);
                FXManager.instance.PlayPowerRed();
                break;

            case 1:
                shield = true;
                FXManager.instance.PlayPowerGreen();
                portal.SendMessage("BonusScore", -400);
                break;
            case 2:
                doubleBall = true;
                portal.SendMessage("BonusScore", -400);
                FXManager.instance.PlayPowerGreen();
                break;
            case 3:
                speed = 2.0f;
                actual_time = Time.time;
                velocityDown = true;
                portal.SendMessage("BonusScore", -400);
                FXManager.instance.PlayPowerGreen();
                break;
            case 4:
                actual_time = Time.time;
                BallSize = new Vector3(1.3f, 1.3f, 1.0f);
                bigBall = true;
                portal.SendMessage("BonusScore", 400);
                FXManager.instance.PlayPowerRed();
                break;
            case 5:
                actual_time = Time.time;
                smallBall = true;
                BallSize = new Vector3(0.7f, 0.7f, 1.0f);
                portal.SendMessage("BonusScore", -400);
                FXManager.instance.PlayPowerGreen();
                break;
            case 6:
                actual_time = Time.time;
                Invisible = true;
                InvisibleColor = new Color(1f, 1f, 1f, 0f);
                transform.GetChild(1).GetComponent<SpriteRenderer>().color = InvisibleColor;
                portal.SendMessage("BonusScore", 400);
                FXManager.instance.PlayPowerRed();
                break;
        }
    }
}
