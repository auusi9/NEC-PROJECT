using UnityEngine;
using System.Collections;

public class MenuBall : MonoBehaviour {

    public Rigidbody2D ball;
    public GameObject TouchAnim;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .7f);
       ball.AddForce(new Vector3(80.0f , 0.0f, 0.0f));
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
            ContactPoint2D contact = col.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            Instantiate(TouchAnim, pos, rot);
            TouchesScript.touches++;
        
    }
    // Update is called once per frame
    void Update () {

        ball.velocity = ball.velocity.normalized * 3.25f;

    }
}
