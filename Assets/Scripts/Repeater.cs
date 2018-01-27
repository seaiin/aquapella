using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour {

    public Color repeaterColor;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave wave = collision.gameObject.GetComponent<Wave>();
            if (wave.CheckOwner(gameObject))
            {
                ChangeColor(wave.GetColor());
                wave.DesWave();
                SpawnWave();
            }
        }
    }

    private void SpawnWave()
    {
        GameObject wave = ObjectPooling.SharedInstance.GetPooledObject("Wave");

        wave.transform.position = gameObject.transform.position;

        if (wave != null)
        {
            wave.SetActive(true);
            wave.SendMessage("SetColor", repeaterColor);
            wave.SendMessage("SetOwner", gameObject);
            FindObjectOfType<AudioManager>().Play("ping");
        }
    }

    public void ChangeColor(Color receiveColor)
    {
        if(gameObject.tag == "RepeaterPos")
        {
            repeaterColor.r = PlusColor(receiveColor.r, repeaterColor.r);
            repeaterColor.g = PlusColor(receiveColor.g, repeaterColor.g);
            repeaterColor.b = PlusColor(receiveColor.b, repeaterColor.b);
        }
        if(gameObject.tag == "RepeaterNeg")
        {
            repeaterColor.r = MinColor(receiveColor.r, repeaterColor.r);
            repeaterColor.g = MinColor(receiveColor.g, repeaterColor.g);
            repeaterColor.b = MinColor(receiveColor.b, repeaterColor.b);
        }
        if(gameObject.tag == "RepeaterInv")
        {
            repeaterColor.r = InvColor(repeaterColor.r);
            repeaterColor.g = InvColor(repeaterColor.g);
            repeaterColor.b = InvColor(repeaterColor.b);
        }
    }

    public float InvColor(float color)
    {
        if(color > 0)
        {
            return 0;
        } else
        {
            return 255.0f;
        }
    }

    public float PlusColor(float a, float b)
    {
        return (a + b) % 255;
    }

    public float MinColor(float a, float b)
    {
        return Mathf.Abs(a - b);
    }
}
