using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brakeysController : MonoBehaviour {
	public float moveSpeed = 10f;
	public float rotationSpeed = 10f;
	float mouseSensitivityX = 250f;
	private float rotation;
	//private Rigidbody rb;

	void Start ()
	{
		//rb = GetComponent<Rigidbody>();
	}

	void Update ()
	{
		rotation = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate ()
	{
		//transform.Rotate(Vector3.up*Input.GetAxis("RHorizontal") + Vector3.right*Input.GetAxis("RVertical") * Time.deltaTime * mouseSensitivityX);
		if (Input.GetAxis ("RHorizontal") != 0) 
		{
			transform.Rotate(new Vector3 (0,Input.GetAxis("RHorizontal"),0));
		}

	}
}
