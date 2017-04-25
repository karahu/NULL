using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	void Start(){
		PlayerPrefs.DeleteKey ("Round");
		if (PlayerPrefs.HasKey("Gun") == true) {
			PlayerPrefs.DeleteKey("Gun");
		}
		PlayerPrefs.SetInt("Gun", 1);
	}

	public void LoadScene(int id){
		if (id == -1) {
			Application.Quit ();
		} else {
			SceneManager.LoadScene (id);
		}
	}
}
