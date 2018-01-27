﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour {

    private int id;

    public int amp;
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

        if (Input.GetKey(KeyCode.Space))
        {
            amp += 10;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnWave();
            amp = 0;
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
