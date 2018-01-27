using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour {

    private Color receiverColor;

    public SpriteRenderer spriteRenderer;

    void Update()
    {
        spriteRenderer.color = receiverColor;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave wave = collision.gameObject.GetComponent<Wave>();
            receiverColor = wave.GetColor();
        }
    }

}
