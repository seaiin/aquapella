using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroVideo : MonoBehaviour {

    public VideoPlayer vplyr;
	// Update is called once per frame
	void Start () {
        vplyr.loopPointReached += EndReached;
	}

    void EndReached(VideoPlayer v)
    {
        Application.LoadLevel("Start");
    }
}
