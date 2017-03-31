using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int damage;

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (gameObject);
	}
}
