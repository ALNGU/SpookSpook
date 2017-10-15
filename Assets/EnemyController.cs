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
            timeUntilSpawn = spawnCooldown;
        }
	}

    private void spawnEnemy(){
        Vector3 newPos = new Vector3(Random.Range(-50, 50), 49, 0);

        GameObject octo = Instantiate(enemy, newPos, Quaternion.identity);

    }
}
