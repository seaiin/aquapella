using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour {

    private float amp;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave wave = collision.gameObject.GetComponent<Wave>();
            if (wave.CheckOwner(gameObject))
            {
                Debug.Log("Hit");
                amp = wave.GetAmp();
                wave.DesWave();
                TransAmp();
                SpawnWave(amp);
            }
        }
    }

    private void SpawnWave(float receiveAmp)
    {
        GameObject wave = ObjectPooling.SharedInstance.GetPooledObject("Wave");

        wave.transform.position = gameObject.transform.position;

        if (wave != null)
        {
            wave.SetActive(true);
            wave.SendMessage("SetAmp", amp);
            wave.SendMessage("SetOwner", gameObject);
            FindObjectOfType<AudioManager>().Play("ping");
        }
    }

    public void SetAmp(float receiveAmp)
    {
        amp = receiveAmp;
    }

    public void TransAmp()
    {
        amp += 1;
    }
}
