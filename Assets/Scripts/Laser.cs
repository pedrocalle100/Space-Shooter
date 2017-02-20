using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public float speed;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.forward * speed;	
	}
}
