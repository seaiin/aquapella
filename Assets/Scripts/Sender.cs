using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {

    private int id;

    public float amp;

    public int minPosX;
    public int maxPosX;
    public int minPosY;
    public int maxPosY;

	// Use this for initialization
	void Start () {
        InitialSender();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().ResetPitch("ping");
            amp = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            // Rate of increase each time it is triggered
            amp += 1;
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
            wave.SendMessage("setAmp", amp);
            wave.SendMessage("setId", id);
            id++;
        }
    }

    private void InitialSender()
    {
        amp = 0;
        id = 1;

        minPosX = -5;
        maxPosX = -3;
        minPosY = -4;
        maxPosY = 4;

        int posX = Random.Range(minPosX, maxPosX);
        int posY = Random.Range(minPosY, maxPosY);

        transform.position = new Vector3(posX, posY, 0);
    }
}
