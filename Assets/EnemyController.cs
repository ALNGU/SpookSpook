using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public float spawnCooldown = 1;
    private float timeUntilSpawn = 0;

    public GameObject enemy;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        timeUntilSpawn -= Time.deltaTime;
        if(timeUntilSpawn <= 0){
            spawnEnemy();
            timeUntilSpawn = spawnCooldown - (.3f * Objective.numCollected); //TODO spawncooldown shortens when game nears end
        }
	}

    private void spawnEnemy(){
        int direction = Random.Range(0, 4);
        Vector3 newPos = new Vector3();
        switch (direction)
        {
            case 0://up
                newPos = new Vector3(Random.Range(-29, 30), 49, 0);
                break;
            case 1: //down
                newPos = new Vector3(Random.Range(-9, 10), -49, 0);
                break;
            case 2: //left
                int spot = Random.Range(0, 3);
                switch (spot) {
                    case 0: //spot 1
                        newPos = new Vector3(-49, Random.Range(-19, 0), 0);
                        break;
                    case 1: //spot 2
                        newPos = new Vector3(-49, Random.Range(10, 30), 0);
                        break;
                    case 2:
                        newPos = new Vector3(-49, Random.Range(-39, -30), 0);
                        break;
                } 
                break;
            case 3:
                spot = Random.Range(0, 3);
                switch (spot)
                {
                    case 0: //spot 1
                        newPos = new Vector3(49, Random.Range(31, 40), 0);
                        break;
                    case 1: //spot 2
                        newPos = new Vector3(49, Random.Range(-9, 20), 0);
                        break;
                    case 2:
                        newPos = new Vector3(49, Random.Range(-39, -20), 0);
                        break;
                }
                break;
        }

        

        GameObject octo = Instantiate(enemy, newPos, Quaternion.identity);

    }
}
