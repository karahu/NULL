using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {

	public GameObject[] guns;

	private int i;

	void Start () {
		while (i < guns.Length) {
			guns[i].SetActive(false);
			i++;
		}

		guns[PlayerPrefs.GetInt("Gun")].SetActive(true); 
	}
}
