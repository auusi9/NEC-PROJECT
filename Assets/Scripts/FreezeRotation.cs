using UnityEngine;
using System.Collections;

public class FreezeRotation : MonoBehaviour {

    Quaternion iniRot;
	// Use this for initialization
	void Start () {
        iniRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = iniRot;
	
	}
}
