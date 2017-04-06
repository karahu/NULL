using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	public GameObject shot;
	public Transform Shotspawn;
	public float fireRate;
	public float delay;
	public float speed; //base speed of the enemy
	public float extraSpeed; // extra speed aplied to melee only enemies to make them a threat
	public float enemyType;
	public float range;
	public bool inRange = false;

	private float shoot;
	private float distance;
	private GameObject player;
	private float chase = 0;
	private Rigidbody2D rb;

	void Start(){

		rb = GetComponent<Rigidbody2D> ();

		player = GameObject.FindGameObjectWithTag ("Player");

		//Decides what the enemy is supposed to do
		if (enemyType == 1) {
			InvokeRepeating ("Shoot", delay, fireRate);
			chase = 1;
		} else if (enemyType == 0) {
			chase = 2;
		}
	}
	//Shoots at player
	void Shoot(){
		if(player != null){
			if (inRange) {
				Instantiate (shot, Shotspawn.position, Shotspawn.rotation);
			}
		}
	}

	void Update(){
		//Chases player
		if (player != null) {	
			if (chase == 1) {
				rb.velocity = transform.up * speed;
			} else if (chase == 2) {
				rb.velocity = transform.up * speed * extraSpeed;
			}
		
			//Checks if player is in range
			distance = Vector3.Distance (transform.position, player.transform.position);
			if (distance <= range) {
				inRange = true;
			} else {
				inRange = false;
			}
		} else {
			chase = 0;
		}
	}

	void FixedUpdate () {
		//Looks at player
		if (player != null) {
			float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

			transform.eulerAngles = new Vector3 (0, 0, z);
		} 
	}
}
