using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour {

	public int lifeTime;
	public GameObject explosion;

	private Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine("Timer");
		StartCoroutine("Slowdown");
	}

	IEnumerator Timer(){
		yield return new WaitForSecondsRealtime(lifeTime);
		Explosion();
	}

	IEnumerator Slowdown(){
		while (rb.velocity.magnitude > 0f) {
			rb.velocity = rb.velocity * 0.9f;
			yield return new WaitForSecondsRealtime(.05f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Explosion();
	}

	void Explosion(){
		Instantiate(explosion, transform.position, transform.rotation);
	}
}
