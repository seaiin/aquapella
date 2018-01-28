using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour {

    private Color receiverColor;
    public Color targetColor;

    void Update()
    {
        if(receiverColor.r == targetColor.r && receiverColor.b == targetColor.b && receiverColor.g == targetColor.g)
        {
            Debug.Log("Yeah! Go to next stage.");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave wave = collision.gameObject.GetComponent<Wave>();
            receiverColor = wave.GetColor();
            wave.DesWave();
            FindObjectOfType<AudioManager>().Play("ping");
        }
    }

}
