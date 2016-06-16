using UnityEngine;
using System.Collections;

public class LevitateMenu : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;
    public float amplitude;

    public Rigidbody2D movecamera;
    private Vector3 tempPosition;
    private Vector3 offset;

    void Start()
    {
        tempPosition = transform.position;
        offset = transform.position - movecamera.transform.position;
    }

    void FixedUpdate()
    {
        if (movecamera.velocity.x > 0 || movecamera.velocity.x < 0)
        {
            transform.position = movecamera.transform.position + offset;
        }
        else
        {
            tempPosition.x += horizontalSpeed;
            tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude + tempPosition.y;
            transform.position = tempPosition;
            offset = transform.position - movecamera.transform.position;
        }
    }
}
