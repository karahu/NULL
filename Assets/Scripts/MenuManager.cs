using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	void Start(){
		PlayerPrefs.DeleteKey ("Round");
		PlayerPrefs.DeleteKey("Gun");
		PlayerPrefs.DeleteKey("Money");

		PlayerPrefs.SetInt("Gun", 1);
		PlayerPrefs.SetInt("Money", 0);
	}

	public void LoadScene(int id){
		if (id == -1) {
			Application.Quit ();
		} else {
			SceneManager.LoadScene (id);
		}
	}
}
