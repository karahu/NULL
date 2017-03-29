using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int Health;

	public static EnemyController Instance;

	void Awake(){
		Instance = this;
	}

	public void hit(int dmg){
		Health = Health - dmg;

		if (Health < 0) {
			DestroyObject (gameObject);
		}
	}
}