using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {

    private int amp;
    private int id;

	// Use this for initialization
	void Start () {
        amp = 0;
        id = 0;
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
            spawnWave();
            amp = 0;
        }
	}

    private void spawnWave()
    {
        GameObject wave = ObjectPooling.SharedInstance.GetPooledObject("Wave");

        wave.transform.position = gameObject.transform.position;

        if (wave != null)
        {
            wave.SetActive(true);
            wave.SendMessage("setAmp", amp);
            wave.SendMessage("setId", id);
            id++;
        }
    }
}
