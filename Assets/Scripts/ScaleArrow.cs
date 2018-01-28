using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetScale(string state)
    {
        if (state == "up")
        {
            gameObject.transform.Rotate(0, 0, 1.33f);
        } else if (state == "down")
        {
            gameObject.transform.Rotate(0, 0, -1.33f);
        } else if (state == "default")
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -45.0f);
        }
    }
}
