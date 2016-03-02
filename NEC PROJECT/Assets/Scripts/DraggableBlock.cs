using UnityEngine;
using System.Collections;

public class DraggableBlock : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public Rigidbody2D Draggableblock;
    Vector3 curPosition;
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
                }
                

                
                
            }
            else if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                {

                    Vector3 curScreenPoint = new Vector3(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y, screenPoint.z);
                    curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                    Draggableblock.velocity = curPosition * 3;
                }
                
            }
        }
    }

}
