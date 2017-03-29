using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public int damage;
	public GameObject player;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			PlayerManager.Instance.hit (damage);
		} else if (other.gameObject.CompareTag ("Enemy")) {
			EnemyController.Instance.hit (damage);
		}
		Destroy (gameObject);
	}
}
