﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour {

    private int choice = 1;
    public Transform posone;
    public Transform postwo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            choice = 1;
            transform.position = posone.position;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            choice = 2;
            transform.position = postwo.position;
        }
        if (choice == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
	}
}
