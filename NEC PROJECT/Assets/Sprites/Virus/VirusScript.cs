using UnityEngine;
using System.Collections;

public class VirusScript : MonoBehaviour {
    int lasttouch = 0;
    Transform ChildwithCHilds;
    int touchstartchild = 0;
    // Use this for initialization
    void Start ()
    {
        ChildwithCHilds = transform.FindChild("VirusSecondHalf"); ;
    }
	
	// Update is called once per frame
	void Update ()
    {
	if(lasttouch != TouchesScript.touches)
        {
            if (transform.childCount > lasttouch)
            { 
                transform.GetChild(lasttouch).gameObject.SetActive(true);
                if(lasttouch != 0 && transform.childCount > lasttouch +1)
                transform.GetChild(lasttouch-1).gameObject.SetActive(false);
                touchstartchild = lasttouch;
            }
            else
            { 
                if (ChildwithCHilds.transform.childCount > (lasttouch-1 - touchstartchild) )
                {
                    ChildwithCHilds.GetChild(lasttouch-1 - touchstartchild).gameObject.SetActive(true);
                    if (lasttouch-1 - touchstartchild != 0)
                        ChildwithCHilds.transform.GetChild(lasttouch-2 - touchstartchild).gameObject.SetActive(false);
                }
                
            }
            
        }
        lasttouch = TouchesScript.touches;
    }
}
