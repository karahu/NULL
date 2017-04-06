using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	public GameObject[] enemies;
	public Transform[] Spawnpoints;
	public float startDelay;
	public float spawnTimes;

	private int i = 0;

	void Start(){
		StartCoroutine ("Spawns");
	}
	//Spawning enemies
	void Spawn(){
		int spawnPointIndex = Random.Range (0, Spawnpoints.Length);
		int enemyType = Random.Range (0, enemies.Length);
		Instantiate (enemies[enemyType], Spawnpoints [spawnPointIndex].position, Spawnpoints [spawnPointIndex].rotation);
	}

	IEnumerator Spawns(){
		while (i < spawnTimes) {
			Invoke ("Spawn", startDelay);
			i++;
			yield return new WaitForSeconds (0.7f);
		}
	}
}
