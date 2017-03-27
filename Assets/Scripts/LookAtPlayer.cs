using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 direction = Player.position - transform.position ;
		// Prevent weird behavior if the player and enemy are very close to each other
//		if( direction.magnitude > 0.1f )
		{
			// If the target is at the right side of the enemy
//			if( Vector3.Dot( Vector3.right, direction ) > 0 )
//				transform.rotation = Quaternion.LookRotation( direction ) * Quaternion.Euler( 0, -90, 0 ) ;
			// If the target is at the left side of the enemy, prevent the sprite to flip
//			else
//				transform.rotation = Quaternion.LookRotation( direction ) * Quaternion.Euler( 0, 90, 180 ) ;
		}
	}
}
