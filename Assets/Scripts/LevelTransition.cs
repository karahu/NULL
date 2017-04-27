using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour {

	public Text SleepText;

	private bool player; 

	//Cheks if player is near the intractable object
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			player = true;
			SleepText.text = "Press 'E' to sleep";
		}

	}

	//Reset the text if players moves away
	void OnTriggerExit2D(Collider2D other){
		SleepText.text = "";
		player = false;
	}

	//Changes level if conditions are met
	void Update(){
		if (Input.GetButtonUp("Use") && player) {
			if (PlayerPrefs.HasKey ("Round") == false) {
				PlayerPrefs.SetInt ("Round", 1);
			} else {
				PlayerPrefs.SetInt ("Round", PlayerPrefs.GetInt ("Round") + 1);
			}
			SceneManager.LoadScene ("Arena");
		}
	}
}
