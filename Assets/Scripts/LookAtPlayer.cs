using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	public GameObject shot;
	public Transform Shotspawn;
	public float fireRate;
	public float delay;
	public float speed;
	public float extraSpeed;
	public float enemyType;

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
		Instantiate (shot, Shotspawn.position, Shotspawn.rotation);
	}

	void Update(){
		//Chases player
		if (chase == 1) {
			rb.velocity = transform.up * speed;
		} else if (chase == 2) {
			rb.velocity = transform.up * speed * extraSpeed;
		}
	}

	void FixedUpdate () {
		//Looks at player
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

		transform.eulerAngles = new Vector3 (0, 0, z);

	}
}
