using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

    // Use this for initialization
    public static bool isPaused = false;
    public GameObject pauseUI;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Resume()
    {
        pauseUI.SetActive(false);
        isPaused = false;
    }
    void Pause()
    {
        pauseUI.SetActive(true);
        isPaused = true;
    }
}
