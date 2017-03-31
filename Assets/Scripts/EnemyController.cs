using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int health;


	void Hit(int dmg){

		if (health > 0) {
			health = health - dmg;
		}

		if (health <= 0) {
			DestroyObject (gameObject);
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Bullet")) {
			Hit (other.GetComponent<DestroyByContact> ().damage);

		}
	}
}