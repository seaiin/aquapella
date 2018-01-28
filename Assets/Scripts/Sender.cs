using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {

    public GameManage gameManage;

    private float amp;
    private Color waveColor;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().ResetPitch("ping");
            amp = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Rate of increase each time it is triggered
            amp = amp + 0.1f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnWave();
            FindObjectOfType<AudioManager>().AlterPitch("ping", amp / 100);
            FindObjectOfType<AudioManager>().Play("ping");
        }
	}

    public void SpawnWave()
    {
        GameObject wave = ObjectPooling.SharedInstance.GetPooledObject("Wave");

        if (wave != null)
        { 
            wave.transform.position = gameObject.transform.position;
            wave.SetActive(true);
            wave.SendMessage("SetColor", GenColor(amp));
            gameManage.SetRun(true);

        }
    }

    public Color GenColor(float amp)
    {
        if(amp < 1)
        {
            waveColor = new Color(255, 0, 0, 255);
        } else if(amp < 2)
        {
            waveColor = new Color(0, 255, 0, 255);
        } else
        {
            waveColor = new Color(0, 0, 255, 255);
        }
        return waveColor;
    }

}
