using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
	public int health;
	public int maxHealth;
	public Slider hp_slider;
	public Text hp_text;

	private bool iframe;

	void Update(){
		hp_slider.value = health;
		hp_text.text = health.ToString() + "/" + maxHealth.ToString() ;
	}

	void Hit(int dmg){

		if (!iframe) {
			if (health > 0) {
				health = health - dmg;
				iframe = true;
				Invoke ("iframeReset", 1);
			}

			if (health <= 0) {
				gameObject.SetActive (false);
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Bullet")) {
			Hit (other.GetComponent<DestroyByContact> ().damage);
		}
	}
	public void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Enemy")) {
			Hit (other.GetComponent<EnemyController> ().damage);
		}
	}

	void iframeReset(){
		iframe = false;
	}
}
