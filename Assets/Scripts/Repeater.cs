using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour {

    public int amp;

    private int ampFac = 100;
    private List<int> waveList = new List<int>();

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave waveEnter = collision.gameObject.GetComponent<Wave>();
            if (!waveList.Contains(waveEnter.waveId) && waveEnter.waveId != 0)
            {
                amp = waveEnter.amp + ampFac;
                SpawnWave();
                waveList.Add(waveEnter.waveId);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wave")
        {
            Wave waveExit = collision.gameObject.GetComponent<Wave>();
            waveList.Remove(waveExit.waveId);
        }
        
    }

    private void SpawnWave()
    {
        GameObject wave = ObjectPooling.SharedInstance.GetPooledObject("Wave");

        wave.transform.position = gameObject.transform.position;

        if (wave != null)
        {
            wave.SetActive(true);
            wave.SendMessage("setAmp", amp);
            amp = 0;
        }
    }

}
