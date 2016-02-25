using UnityEngine;
using System.Collections;

public class DraggableBlock : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public Rigidbody2D Draggableblock;
    Vector3 curPosition;
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
 
}
