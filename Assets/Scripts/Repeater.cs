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
        repeaterColor.r = repeaterColor.r + receiveColor.r;
        repeaterColor.g = repeaterColor.g + receiveColor.g;
        repeaterColor.b = repeaterColor.b + receiveColor.b;
        repeaterColor.a = repeaterColor.a + receiveColor.a;
    }
}
