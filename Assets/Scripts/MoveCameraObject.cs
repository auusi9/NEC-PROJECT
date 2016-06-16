using UnityEngine;
using System.Collections;

public class MoveCameraObject : MonoBehaviour {
    int lastworld = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if(LevelManager.world != lastworld)
        {
            if(lastworld == 10 && LevelManager.world == 1)
            {
                if (transform.position.x > 0f)
                {
                    transform.position = Vector3.zero;
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    lastworld = LevelManager.world;
                }
            }
            else if(lastworld == 1 && LevelManager.world == 10)
            {
                if (transform.position.x < 0f)
                {
                    transform.position = Vector3.zero;
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    lastworld = LevelManager.world;
                }

            }
            else { 
            if (LevelManager.world - lastworld >= 1)
            {
                if(transform.position.x > 0f)
                {
                    transform.position = Vector3.zero;
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    lastworld = LevelManager.world;
                }
            }
            else
            {
                if (transform.position.x < 0f)
                {
                    transform.position = Vector3.zero;
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                    lastworld = LevelManager.world;
                }

            }
            }
        }

    }
}
