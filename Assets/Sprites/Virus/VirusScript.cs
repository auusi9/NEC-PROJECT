using UnityEngine;
using System.Collections;

public class VirusScript : MonoBehaviour {
    int lasttouch = 0;
    int touchstartchild = 0;
    public GameObject Son;
    
    void OnEnable()
    {
        touchstartchild = TouchesScript.touches;
        Debug.Log("IM HERE");
    }
	
	// Update is called once per frame
	void Update ()
    {

	if(lasttouch != (TouchesScript.touches - touchstartchild))
        {
            if (transform.childCount > lasttouch)
            { 
                transform.GetChild(lasttouch).gameObject.SetActive(true);
                if(lasttouch != 0 && transform.childCount > lasttouch +1)
                transform.GetChild(lasttouch-1).gameObject.SetActive(false);
               
            }
            else
            {
                if(Son != null)
                       Son.SetActive(true);
                
            }
            
        }

        lasttouch = (TouchesScript.touches - touchstartchild);
    }
}
