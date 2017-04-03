using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GunController : MonoBehaviour {

	public Camera camera;

	public Transform shotspawn;
	public GameObject shot;
	public float fireRate;
	public float nextFire;

	public GameObject gun;

	void Start(){

		if (SceneManager.GetActiveScene ().name == "Main") {
			nextFire = Mathf.Infinity;
			gun.SetActive (false);
		} else if (SceneManager.GetActiveScene ().name != "Main") {
			nextFire = 0;
			gun.SetActive (true);
		}


	}

	void Update () {

		//Turn character to face the mouse
		var target = camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,camera.nearClipPlane));

		transform.LookAt (target, Vector3.forward);
		transform.eulerAngles = new Vector3 (0, 0, -transform.eulerAngles.z); 

		//Calls shoot function
		Shoot ();

	}

	void Shoot(){

		//Checks if player is pressing the mouse1 button and fires
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;	
			Instantiate (shot, shotspawn.position, shotspawn.rotation);

		}

	}
}
