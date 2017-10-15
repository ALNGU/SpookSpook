using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

    public static int numCollected = 0;
    public static int maxCollected = 9;
    public float collectTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        collectTime += Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && collectTime >= 1)
        {
            Destroy(this.gameObject);
            collectTime = 0;
            numCollected += 1;
            Debug.Log("numCollected = " + numCollected);
            if(numCollected == maxCollected)
            {
                Debug.Log("You Won!");
            }
        }
    }
}
