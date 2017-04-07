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
	public bool dead = false;
	public Text reloadText;

	private Rigidbody2D rb;
	private GameObject gun;
	private GunController guncont;
	private PlayerMovement pcmove;
	private Collider2D collider;
	private bool iframe;

	void Start(){
		pcmove = GetComponent<PlayerMovement> ();
		gun = GameObject.FindGameObjectWithTag ("Gun");
		guncont = gun.GetComponent<GunController> ();
		collider = GetComponent<Collider2D> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		//Updating hp bar
		hp_slider.value = health;
		hp_text.text = health.ToString() + "/" + maxHealth.ToString() ;

		//Restart
		if (dead && Input.GetButtonUp ("Reload")) {
			SceneManager.LoadScene ("Main");
		}
	}

	void Hit(int dmg){
		//Taking dmg & dying
		if (!iframe) {
			if (health > 0) {
				health = health - dmg;
				iframe = true;
				Invoke ("iframeReset", 1);
			}

			if (health <= 0) {
				guncont.enabled = false;
				pcmove.enabled = false;
				collider.enabled = false;
				rb.velocity = new Vector2 (0, 0);
				dead = true;
				reloadText.text = "Press 'R' to restart";
				PlayerPrefs.DeleteKey ("Round");
			}
		}
	}
	//Checks if player gets hit
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
	//Reset the iframe
	void iframeReset(){
		iframe = false;
	}
}
