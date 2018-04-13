﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour 
{

	public Transform target;

	public float smoothness = 1f;
	public float rotationSmoothness = .1f;

	public Vector3 offset;

	private Vector3 velocity = Vector3.zero;

	void FixedUpdate()
	{
		if (target == null) {
			return;
		}

		Vector3 newPos = target.TransformDirection (offset);
		transform.position = Vector3.SmoothDamp (transform.position, newPos + target.transform.position, ref velocity, smoothness);
		Quaternion targetRot = Quaternion.LookRotation (-transform.position.normalized, target.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRot, Time.deltaTime * rotationSmoothness);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
