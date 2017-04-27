using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {

	public Text infoText;
	public int gun_id;
	public GameObject storeUI;
	public int[] cost;
	public Text moneyText;
	public GameObject[] guns;

	private bool player = false;
	private int i = 0;

	void Start () {
		storeUI.SetActive(false);
	}

	//Interacting with store
	void Update () {
		if (player && Input.GetButtonUp("Use")) {
			storeUI.SetActive(true);
		}
		moneyText.text = PlayerPrefs.GetInt("Money").ToString();
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
		while (PlayerPrefs.GetInt("Money") >= cost[id]) {
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - cost[id]);
			GunDisable();
			guns[id].SetActive(true);
			PlayerPrefs.SetInt("Gun", id);
		}
	}

	//Set all guns as inactive
	void GunDisable(){
		while (i < guns.Length) {
			guns[i].SetActive(false);
			i++;
		}
	}
}
