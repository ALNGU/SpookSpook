using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverAmmoView : MonoBehaviour {
    public Sprite[] images;
    PlayerMovement player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Image>().sprite = images[6 - player.ammoCount];
	}
}
