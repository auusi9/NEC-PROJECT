using UnityEngine;
using System.Collections;

public class DeathStar : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    void FixedUpdate()
    {
        rb.angularVelocity = 90.0f;
    }
}
