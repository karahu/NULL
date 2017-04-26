using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {

	public int value;
	public Canvas pickupText;
	public Rigidbody2D rb;

	void Start(){
		rb = GetComponent<Rigidbody2D>();
		StartCoroutine("Slowdown");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Player")) {
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + value);
			Instantiate(pickupText, transform.position, transform.rotation);
			StartCoroutine("Fade");
			Destroy(gameObject);
		}
	}

	IEnumerator Fade(){
		yield return new WaitForSecondsRealtime(2f);
		//infoText.text = "";
	}

	IEnumerator Slowdown(){
		while (rb.velocity.magnitude > 0f) {
			rb.velocity = rb.velocity * 0.9f;
			yield return new WaitForSecondsRealtime(0.005f);
		}
	}
}
