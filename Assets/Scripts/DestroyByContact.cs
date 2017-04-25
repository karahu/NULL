using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int damage;

	//Destrois the bullet when it hits something
	void OnTriggerEnter2D(Collider2D other) {
		Destroy (gameObject, .01f);
	}
}
