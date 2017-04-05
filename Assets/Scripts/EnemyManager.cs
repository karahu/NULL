using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public GameObject[] enemies;
	public Transform[] Spawnpoints;
	public float startDelay;
	public float spawnDelay;


	void Start(){
		
		InvokeRepeating ("Spawn", startDelay, spawnDelay);
	}

	void Spawn(){
		int spawnPointIndex = Random.Range (0, Spawnpoints.Length);
		int enemyType = Random.Range (0, enemies.Length);
		Instantiate (enemies[enemyType], Spawnpoints [spawnPointIndex].position, Spawnpoints [spawnPointIndex].rotation);
	}
}
