using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private float amp;
    private float radius;
    private string color;
    private GameObject owner;

    public CircleCollider2D circleCollider2D;
    public SpriteRenderer spriteRenderer;

	void OnEnable () {
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        amp = 0;
        radius = 0;
    }
	
	void Update () {
        radius += 0.01f;
        circleCollider2D.radius = radius;
        RadBoundary();
    }


    public void SetAmp(float receiveAmp)
    {
        amp = receiveAmp;
    }

    public float GetAmp()
    {
        return amp;
    }

    public void RadBoundary()
    {
        if (radius >= 10)
        {
            radius = 0;
            circleCollider2D.radius = radius;
            gameObject.SetActive(false);
        }
    }

    public void SetColor(int ampli)
    {
        if(ampli < 1)
        {
            color = "Red";
        } else if(ampli < 2)
        {
            color = "Blue";
        } else if (ampli < 3)
        {
            color = "Yellow";
        }
    }

    public string GetColor()
    {
        return color;
    }

    public void DesWave()
    {
        gameObject.SetActive(false);
    }

    public void SetOwner(GameObject obj)
    {
        owner = obj;
    }

    public bool CheckOwner(GameObject obj)
    {
        return owner != obj;
    }
}
