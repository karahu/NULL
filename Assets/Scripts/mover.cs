using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb;

	//Moves the bullets forward

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up * speed;
	}
}
