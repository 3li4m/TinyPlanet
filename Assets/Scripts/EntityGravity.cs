using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityGravity : MonoBehaviour {

	GravAttractor grav;
	Rigidbody rb;
	// Use this for initialization
	void Awake () 
	{
		rb =  GetComponent<Rigidbody>();
		grav = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravAttractor> ();
		rb.useGravity = false;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
	}
	void FixedUpdate () 
	{
		grav.Attract(rb);	
	}
}
