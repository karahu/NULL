using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
	public int Health;
	public Slider hp_slider;

	public static PlayerManager Instance;

	void Awake(){
		Instance = this;
	}

	void Update(){
		hp_slider.value = Health;
	}

	public void hit(int dmg){

		if (Health > 0) {
			Health = Health - dmg;
		}

		if (Health <= 0) {
			enabled = false;
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
