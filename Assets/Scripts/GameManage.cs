using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    public Sender sender;
    public Camera mainCamera;
    
    private bool isRun = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void SetRun(bool run)
    {
        isRun = run;
    }

    public bool GetRun()
    {
        return isRun;
    }
}
