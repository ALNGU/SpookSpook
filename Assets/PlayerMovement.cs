using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public float speed = 4.0f;
    public float highSpeed = 7.0f;
    public GameObject bullet;
    public GameObject knife;
    public float gunCooldown;
    private Rigidbody2D rb2d;
    public int ammoCount = 6;

    public float initHealthPos;
    public Image damageImage;
    public RectTransform damageBar;
    public RectTransform damageBox;

    private float currStam;
    public float maxStam;
    private bool running = false;
    public float maxRestTime = 2.0f;
    private float restTime;
    // Use this for initialization
    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        currStam = maxStam;
    }

    // Update is called once per frame
    void Update() {
        
        readKeys();
        updateStamina();
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
        if (running)
        {
            horizMove = Input.GetAxis("Horizontal") * highSpeed;
            vertMove = Input.GetAxis("Vertical") * highSpeed;
        }

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
        if (Input.GetButtonDown("Fire2") && gunCooldown < 0 && currStam > 0)
        {
            GameObject playKnife = Instantiate(knife, transform.position + transform.right * .75f - transform.up * .5f, Quaternion.identity, transform);
            playKnife.transform.rotation = this.transform.rotation;
            Debug.Log("Knifed");
            rb2d.velocity = new Vector2(0, 0);
            gunCooldown = .6f;
            currStam -= 20;
            restTime = 0;
        }
        if (Input.GetButton("Fire3") && currStam > 0)
        { //sprint
            running = true;
            currStam -= Time.deltaTime * 20;
            restTime = 0;
        }
        if(Input.GetButtonUp("Fire3") || currStam <=0) {
            running = false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ammo")
        {
            Destroy(other.gameObject);
            ammoCount += 3;
            if(ammoCount > 6)
            {
                ammoCount = 6;
            }
            
        }
    }

    void updateStamina()
    {
        Color barColor = Color.Lerp(Color.red, Color.yellow, currStam / (float)maxStam);
        barColor.a = 1;
        damageBar.sizeDelta = new Vector2((currStam) / (float)maxStam * damageBox.rect.width, 20);
        /*damageBar.position = new Vector3(initHealthPos - (1 - (currStam) / (float)maxStam) * (damageBox.rect.width / 2),
                                               damageBar.position.y, 0);*/
        damageImage.color = barColor;
        restTime += Time.deltaTime;
        if(restTime >= maxRestTime && currStam < maxStam)
        {
            currStam += Time.deltaTime * 30;
        }
    }
}
