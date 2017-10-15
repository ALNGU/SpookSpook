using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public GameObject player;
    public float speed = 3.0f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;
        //transform.position = new Vector3(playerPos.x, playerPos.y, -1);
        switch (moveDirection(playerPos)){
            case "north":
               transform.Translate(0, speed * Time.deltaTime, 0);
                break;
            case "east":
                transform.Translate(speed * Time.deltaTime, 0 , 0);
                break;
            case "south":
                transform.Translate(0, - speed * Time.deltaTime, 0);

                break;
            case "west":
                transform.Translate(- speed * Time.deltaTime, 0, 0);

                break;
                
        }
	}
    string moveDirection(Vector3 playerPos){
        float playerX = playerPos.x;
        float playerY = playerPos.y;

        float enemyX = transform.position.x;
        float enemyY = transform.position.y;

        float diffX = enemyX - playerX;
        float diffY = enemyY - playerY;

        if (Mathf.Abs(diffX) > Mathf.Abs(diffY))
        { // need to move in X direction
            if (diffX > 0){
                return "west";
            }else{
                return "east";
            }

        }
        else // need to move in Y direction
        {
            if (diffY > 0){
                return "south";
            }else{
                return "north";
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            Destroy(other.gameObject);
        }
    }
}
