using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverDestroy : MonoBehaviour {

	public Sprite cover;
	public float health;

	private SpriteRenderer renderer;
	private Collider2D collider;

	void Start(){
		renderer = GetComponent<SpriteRenderer> ();
		collider = GetComponent<Collider2D> ();
	}

	void Hit(int dmg){
		if (health > 0) {
			health -= dmg;
		}
		if (health <= 0) {
			//"Destroys" cover, use renderer.sprite to change sprite
			renderer.color = new Color (0, 0, 0, 255f);
			collider.enabled = false;
		}
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Bullet")) {
			Hit (other.GetComponent<DestroyByContact> ().damage);
		}
	}
}
