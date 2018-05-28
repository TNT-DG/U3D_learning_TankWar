﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed = 10.0f;

	// Use this for initialization
	void Start () {
	
        
        	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World); 
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}