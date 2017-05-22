using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerScript : MonoBehaviour {

	public ParticleSystem flames;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			flames.Play();
		}
		if (Input.GetButtonUp("Fire1")) {
			flames.Stop();
		}
	}
}
