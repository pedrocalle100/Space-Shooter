using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public float speed;
	public Rigidbody rb;
	public Limit limit;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	public float nextFire;


	[System.Serializable]
	public class Limit{
		public float xMin, zMin, xMax, zMax;
	}

	//función que genera disparos de la nave

	void Update(){
		if (Input.GetKey(KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	// función que mueve la nave

	void FixedUpdate(){
		float movementHorizontal = Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (movementHorizontal, 0.0f, movementVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3(
			Mathf.Clamp(rb.position.x, limit.xMin, limit.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, limit.zMin, limit.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);

	}
}
