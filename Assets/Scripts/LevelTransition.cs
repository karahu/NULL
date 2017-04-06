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
	}

	//Changes level if conditions are met
	void Update(){
		if (Input.GetButtonUp("Use") && player) {
			SceneManager.LoadScene ("Arena");
		}
	}
}
