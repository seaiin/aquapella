using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private float radius;
    private float scale;
    private Color waveColor;
    private GameObject owner;

    public CircleCollider2D circleCollider2D;
    public SpriteRenderer spriteRenderer;

	void OnEnable () {
        scale = 0.3f;
        radius = 4f;
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
    }
	
	void Update () {
        radius += 0.0007f;
        scale += 0.007f;
        gameObject.transform.localScale = new Vector3(scale, scale, 1);
        circleCollider2D.radius = radius;
        RadBoundary();
    }

    public void SetColor(Color receiveColor)
    {
        waveColor = receiveColor;
        spriteRenderer.color = waveColor;
    }

    public void RadBoundary()
    {
        if (radius >= 5)
        {
            radius = 0;
            circleCollider2D.radius = radius;
            gameObject.SetActive(false);
        }
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

    public Color GetColor()
    {
        return waveColor;
    }
}
