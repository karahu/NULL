using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

	public Camera camera;

	public Transform shotspawn;
	public GameObject shot;
	public float fireRate;
	public float nextFire;
	public GameObject gun;
	public float ammo;
	public float maxAmmo;
	public Text ammoText;
	public Text reloadText;
	public float reloadTime;
	private bool reloading = false;

	void Start(){
		
		//Checks what chene is active
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
		ammoText.text = ammo.ToString ();
		//Checks if player is allowed to shoot and shoots
		if (Input.GetButton ("Fire1") && Time.time > nextFire && ammo > 0) {
			ammo = ammo -1;
			nextFire = Time.time + fireRate;	
			Instantiate (shot, shotspawn.position, shotspawn.rotation);

		} else if (ammo == 0 && reloading == false || Input.GetButtonDown("Reload") && reloading == false) {
			//Reloading
			ammo = 0;
			reloading = true;
			reloadText.text = "Reloading...";
			Invoke("Reload",reloadTime);
		}
	}

	void Reload(){
		ammo = maxAmmo;
		reloadText.text = "";
		reloading = false;
	}

}

