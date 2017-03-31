using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
	public int health;
	public Slider hp_slider;

	void Update(){
		hp_slider.value = health;
	}

	void Hit(int dmg){

		if (health > 0) {
			health = health - dmg;
		}

		if (health <= 0) {
			gameObject.SetActive (false);
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Bullet")) {
			Hit (other.GetComponent<DestroyByContact> ().damage);

		}
	}
}
