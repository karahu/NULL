using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){

	}

	void FixedUpdate () {

		//Movement
		float inputv = Input.GetAxis ("Vertical");
		float inputh = Input.GetAxis ("Horizontal");
		rb.velocity = new Vector2 (inputh * speed,inputv * speed);

	}
}
