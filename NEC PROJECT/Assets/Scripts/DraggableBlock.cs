using UnityEngine;
using System.Collections;

public class DraggableBlock : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public Rigidbody2D Draggableblock;
    Vector3 curPosition;
    int[] touched = new int[5];
    /*
    void OnMouseDown()
    {

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);


        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }


    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);


        curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        Draggableblock.velocity = curPosition * 3;

    }


    void OnMouseUp() {

        Draggableblock.velocity = Vector3.zero;
    }
    */
    
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {

                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {
                    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, screenPoint.z));
                    touched[i] = 1;
                }
                else
                {
                    touched[i] = 0;
                }
       
                
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
               
                if(touched[i] == 1) {

                    Vector3 curScreenPoint = new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, screenPoint.z);
                    curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                    Draggableblock.velocity = curPosition.normalized * Input.GetTouch(i).deltaPosition.sqrMagnitude;
                }


            }
            else if(Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Draggableblock.velocity = Vector2.zero;
                screenPoint = Vector2.zero;
                offset = Vector2.zero;

            }
        }
    }

}
