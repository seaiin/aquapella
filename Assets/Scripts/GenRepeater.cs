using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenRepeater : MonoBehaviour {

    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;

    public int repCount = 5;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < repCount; i++)
        {
            InitialRepeater();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitialRepeater()
    {
        minPosX = -2;
        maxPosX = 3;
        minPosY = -4;
        maxPosY = 4;

        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);

        SpawnRepeater(posX, posY);
    }

    private void SpawnRepeater(float x, float y)
    {
        GameObject repeater = ObjectPooling.SharedInstance.GetPooledObject("Repeater");

        if (repeater != null)
        {
            repeater.transform.position = new Vector3(x, y, 0);
            repeater.SetActive(true);
        }
    }
   
}
