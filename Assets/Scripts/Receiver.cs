using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour {

    public float amp;
    public int minPosX;
    public int maxPosX;
    public int minPosY;
    public int maxPosY;

    // Use this for initialization
    void Start () {

        InitialReceive();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave wave = collision.gameObject.GetComponent<Wave>();
            amp = wave.GetAmp();
        }
    }

    private void InitialReceive()
    {
        amp = 0;

        minPosX = 4;
        maxPosX = 6;
        minPosY = -4;
        maxPosY = 4;

        int posX = Random.Range(minPosX, maxPosX);
        int posY = Random.Range(minPosY, maxPosY);

        transform.position = new Vector3(posX, posY, 0);
    }

}
