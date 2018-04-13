using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	Rigidbody rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	public void setSpeed (float newSpeed) {
		speed = newSpeed;
	}
	void FixedUpdate () 
	{
		rb.MovePosition (rb.position + transform.forward * speed * Time.deltaTime);
	}
}
