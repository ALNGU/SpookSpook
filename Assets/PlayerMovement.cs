using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
    public float speed = 4.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        readKeys();
	}

    void readKeys()
    {
        float horizMove = Input.GetAxis("Horizontal") * speed;
        float vertMove = Input.GetAxis("Vertical") * speed;
        //only move in the direction more drastically pressed down
        if((Math.Abs(horizMove) > Math.Abs(vertMove))) {
            horizMove *= Time.deltaTime;
            transform.Translate(horizMove, 0, 0);
        }
        else
        {
            vertMove *= Time.deltaTime;
            transform.Translate(0, vertMove, 0);
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fired!");
        }
    }
}
