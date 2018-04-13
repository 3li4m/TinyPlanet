using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (GunController))]
public class PlayerController : MonoBehaviour 
{
	//public float moveSpeed = 10f;
	public float rotationSpeed = 10f;
	private float rotation; 
	public float moveSpeed = 4;
	public int jumpForce = 10;
	public bool grounded;

	public bool controller;

	public LayerMask groundedMask;

	Vector3 moveVelocity;
	Vector3 moveInput;
	Rigidbody rb;

	public GunController gun;

	void Start () 
	{
		
		rb = GetComponent<Rigidbody> ();
	}
		

	public void Update()
	{
		moveInput = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized;
		moveVelocity = moveInput.normalized * moveSpeed;

		if (!controller) {
			if (Input.GetMouseButton (0)) {
				gun.Shoot ();
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (grounded) {
					rb.AddForce (transform.up * jumpForce);
				}
			}
		} else {
			if (Input.GetButtonDown ("Xbox Jump")) {
				if (grounded) {
					rb.AddForce (transform.up * jumpForce);
				}
			}
		}

		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1 + .1f, groundedMask)) {
			grounded = true;
		} else {
			grounded = false;
		}
	}
		
	void FixedUpdate () 
	{
		Vector3 localMove = transform.TransformDirection(moveVelocity) * Time.fixedDeltaTime;
		rb.MovePosition (rb.position + localMove * moveSpeed * Time.deltaTime);
	}
}
