﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowLightLock : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    private string parentTag;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        spriteRenderer.color = transform.parent.GetComponent<RepeaterLock>().repeaterColor;
    }
}
