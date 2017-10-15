using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
    public float speed = 4.0f;
    public GameObject bullet;
    public GameObject knife;
    public float gunCooldown;
    private Rigidbody2D rb2d;
    public int ammoCount = 6;
    // Use this for initialization
    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
        readKeys();
        
        gunCooldown -= Time.deltaTime;
    }

    void setRotation()
    {
        Vector2 moveDirection = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void readKeys()
    {
        float horizMove = Input.GetAxis("Horizontal") * speed;
        float vertMove = Input.GetAxis("Vertical") * speed;
        //only move in the direction more drastically pressed down
        if(gunCooldown < .25f) {
            if ((Math.Abs(horizMove) > Math.Abs(vertMove)))
            {

                rb2d.velocity = new Vector2(horizMove, 0);


            }
            else
            {
                rb2d.velocity = new Vector2(0, vertMove);
            }
            setRotation();
        }
        if (Input.GetButtonDown("Fire1") && gunCooldown < 0 && ammoCount > 0)
        {
            GameObject playBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            playBullet.transform.rotation = this.transform.rotation;
            rb2d.velocity = -transform.right * .4f;
            Debug.Log("Fired!");
            gunCooldown = .75f;
            ammoCount--;
        }
        if (Input.GetButtonDown("Fire2") && gunCooldown < 0)
        {
            GameObject playKnife = Instantiate(knife, transform.position + transform.right * .75f - transform.up * .5f, Quaternion.identity, transform);
            playKnife.transform.rotation = this.transform.rotation;
            Debug.Log("Knifed");
            rb2d.velocity = new Vector2(0, 0);
            gunCooldown = .75f;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ammo Pickup");
        if (other.gameObject.tag == "Ammo")
        {
            
            ammoCount += 3;
            if(ammoCount > 6)
            {
                ammoCount = 6;
            }
            Destroy(other.gameObject);
        }
    }
}
