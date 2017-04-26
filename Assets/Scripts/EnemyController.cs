using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int health;
	public int damage;
	public GameObject money;

	private float moneyrot;

	//Taking dmg
	void Hit(int dmg){

		if (health > 0) {
			health = health - dmg;
		}

		if (health <= 0) {
			Death();
		}
	}

	//Checks if the enemy gets hit or not
	public void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Bullet")) {
			Hit (other.GetComponent<DestroyByContact> ().damage);

		}
	}

	void Death(){
		Destroy(gameObject);
		Instantiate(money, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
	}
}