using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchInputHandler : MonoBehaviour
{

    public LayerMask touchInputMask;
    private List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;
    private GameObject[] touchArray = new GameObject[5];
    

    private RaycastHit2D hit;


    // Use this for initialization
    void Start()
    {
       // camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN	
        // if unity editor // Mouse Input

        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up, 0, touchInputMask);
            GameObject recipient;
            
            if (hit.collider != null)
            {
                recipient = hit.transform.gameObject;
                touchList.Add(recipient);

                if (Input.GetMouseButtonDown(0))
                {
                    recipient.SendMessage("onTouchDown", Input.mousePosition);
                    
                }
                if (Input.GetMouseButtonUp(0))
                {
                    recipient.SendMessage("onTouchUp", Input.mousePosition, SendMessageOptions.DontRequireReceiver);
                }
                if (Input.GetMouseButton(0))
                {
                    recipient.SendMessage("onTouchStay", Input.mousePosition, SendMessageOptions.DontRequireReceiver);
                }
            }
            
            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("onTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }

        // endif unity editor

#endif

        if (Input.touchCount > 0)
        {
            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            for (int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);
                hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y)), -Vector2.up, 0 , touchInputMask);
                if (hit.collider != null)
                {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);
                    
                    if (touch.phase == TouchPhase.Began)
                    {
                        touchArray[i] = recipient;
                        touchArray[i].SendMessage("onTouchDown", new Vector3(touch.position.x, touch.position.y));
                    }
                }

                if(touchArray[i] != null)
                { 
                    if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        touchArray[i].SendMessage("onTouchStay", new Vector3(touch.position.x, touch.position.y), SendMessageOptions.DontRequireReceiver);
                    }
                    if(touch.phase == TouchPhase.Ended)
                    {
                        touchArray[i].SendMessage("onTouchUp", new Vector3(touch.position.x, touch.position.y), SendMessageOptions.DontRequireReceiver);
                        touchArray[i] = null;
                    }
                }
            }

            foreach (GameObject g in touchesOld)
            {
                if (!touchList.Contains(g))
                {
                    g.SendMessage("onTouchExit", SendMessageOptions.DontRequireReceiver);
                }
            }
        }

    }
}