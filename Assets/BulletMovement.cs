using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1f);
        rb2d = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb2d.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy Hit");
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
