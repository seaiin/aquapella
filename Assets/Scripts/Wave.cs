using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private int amp;
    SphereCollider sphereCollider;

	// Use this for initialization
	void Start () {
        amp = 0;
	}
	
	// Update is called once per frame
	void Update () {
        sphereCollider.radius += 0.1f;
	}

    public void setAmp(int receiveAmp)
    {
        sphereCollider = GetComponent<SphereCollider>();
        amp = receiveAmp;
        Debug.Log("Wave Amp : " + amp);
    }
}
