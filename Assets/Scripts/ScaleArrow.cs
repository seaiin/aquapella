using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleArrow : MonoBehaviour {

    public Sender sender;

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
            gameObject.transform.RotateAround(sender.transform.position, Vector3.forward, 1.33f);
        } else if (state == "down")
        {
            gameObject.transform.RotateAround(sender.transform.position, Vector3.back, 1.33f);
        } else if (state == "default")
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -135.0f);
            gameObject.transform.position = new Vector3(-11, -1f, 0.05f);
        } else if (state == "shot")
        {
            gameObject.transform.RotateAround(sender.transform.position, Vector3.back, 2.66f);
        }
    }
}
