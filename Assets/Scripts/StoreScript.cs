using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {

	public Text infoText;
	public int gun_id;
	public GameObject storeUI;

	private bool player = false;
	public GameObject[] guns;
	private int i = 0;

	void Start () {
		
	}

	//Interacting with store
	void Update () {
		if (player && Input.GetButtonUp("Use")) {
			storeUI.SetActive(true);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			player = true;
			infoText.text = "Press 'E' to open the store";
		}
	}

	void OnTriggerExit2D(Collider2D other){
		player = false;
		infoText.text = "";
		storeUI.SetActive(false);
	}

	//Set the new gun as active
	public void GunPurchase(int id){
		GunDisable();
		guns[id].SetActive(true);
		PlayerPrefs.SetInt("Gun", id);
		//Debug.Log(PlayerPrefs.GetInt(""))
	}

	//Set all guns as inactive
	void GunDisable(){
		while (i < guns.Length) {
			guns[i].SetActive(false);
			i++;
		}
	}
}
