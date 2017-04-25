using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour {
	public GameObject[] enemies;
	public Transform[] Spawnpoints;
	public float startDelay;
	public Text txt;
	public Text roundText;
	[SerializeField]
	private int round = 1;
	private int[] spawnTimes = {0,5,10,15,20,25,30};
	private bool done = false;
	private int i = 0;

	void Awake(){
		if (PlayerPrefs.HasKey ("Round") == false) {
			round = 1;
			PlayerPrefs.SetInt ("Round", round);
		} else {
			round = PlayerPrefs.GetInt ("Round");
		}
		roundText.text = "Day " + round.ToString();
	}

	void Start(){
		StartCoroutine ("Spawns");

	}

	void Update(){
		if (GameObject.FindGameObjectWithTag("Enemy") == null && done == true) {
			txt.text = "Press 'Enter' to return to your shell";
			if( Input.GetButtonUp ("Submit")){
				SceneManager.LoadScene ("Main");
			}

		}
	}
	//Spawning enemies
	void Spawn(){
		int spawnPointIndex = Random.Range (0, Spawnpoints.Length);
		int enemyType = Random.Range (0, enemies.Length);
		Instantiate (enemies[enemyType], Spawnpoints [spawnPointIndex].position, Spawnpoints [spawnPointIndex].rotation);
	}

	IEnumerator Spawns(){
		while (i < spawnTimes[round]) {
			Invoke ("Spawn", startDelay);
			i++;
			yield return new WaitForSeconds (0.7f);
		}
		if (i >= spawnTimes[round]) {
			done = true;
		}
	}
}
