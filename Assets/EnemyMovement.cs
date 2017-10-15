using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = player.transform.position;
        //transform.position = new Vector3(playerPos.x, playerPos.y, -1);
        switch (moveDirection(playerPos)){
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
                
        }
	}
    int moveDirection(Vector3 playerPos){
        float playerX = playerPos.x;
        float playerY = playerPos.y;

        float enemyX = transform.position.x;
        float enemyY = transform.position.y;

        float diffX = playerX - enemyX;
        float diffY = playerY - enemyY;

        if (diffX > 0 ){
            
        }else if (){
            
        }else if(){
            
        }else{
            
        }
    }
}
