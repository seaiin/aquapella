using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {

    private int amp;

	// Use this for initialization
	void Start () {
        amp = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            amp += 10;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log(amp);
            waveSpawn();
            amp = 0;
        }
	}

    private void waveSpawn()
    {
        GameObject wave = ObjectPooling.SharedInstance.GetPooledObject("Wave");

        if (wave != null)
        {
            wave.SetActive(true);
            wave.SendMessage("setAmp", amp);

            for (int i = 0; i < wave.transform.childCount; i++)
            {
                wave.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
