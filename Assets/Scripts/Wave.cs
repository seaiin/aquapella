using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public int amp;
    public CircleCollider2D circleCollider2D;
    public float radius;
    public int numSegments = 128;
    public int waveId = 0;

	void OnEnable () {
        amp = 0;
    }
	
	void Update () {
        circleCollider2D.radius = radius;
        radius += 0.01f;
        CirRender();
        radBoundary();
    }

    public void CirRender()
    {
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Color c1 = new Color(0.5f, 0.5f, 0.5f, 1);
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c1);
        lineRenderer.SetWidth(0.1f, 0.1f);
        lineRenderer.SetVertexCount(numSegments + 1);
        lineRenderer.useWorldSpace = false;

        float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

    public void setAmp(int receiveAmp)
    {
        amp = receiveAmp;
    }

    public void radBoundary()
    {
        if (radius >= 5)
        {
            radius = 0;
            circleCollider2D.radius = radius;
            CirRender();
            waveId = 0;
            gameObject.SetActive(false);
        }
    }

    public int getAmp()
    {
        return amp;
    }

    public void setId(int id)
    {
        if (waveId == 0)
        {
            waveId = id;
        }
    }
}
