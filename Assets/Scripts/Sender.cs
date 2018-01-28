using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {

    public GameManage gameManage;
    public ScaleArrow scaleArrow;

    private float amp = 0;
    private string stateAmp = "default";
    private Color waveColor;

	void Update () {
        Debug.Log(stateAmp);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().ResetPitch("ping");
            if (stateAmp == "default")
            {
                stateAmp = "up";
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Rate of increase each time it is triggered
            if (stateAmp == "up")
            {
                amp = amp + 0.05f;
            } else if (stateAmp == "down") {
                amp = amp - 0.05f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            amp = 0;
            SpawnWave();
            stateAmp = "default";
            FindObjectOfType<AudioManager>().AlterPitch("ping", amp / 100);
            FindObjectOfType<AudioManager>().Play("ping");
        }

        scaleArrow.SetScale(stateAmp);
        SetState();
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

    public void SetState()
    {
        if(amp >= 3)
        {
            stateAmp = "down";
        } else if (amp < 0)
        {
            stateAmp = "up";
        }
    }
}
