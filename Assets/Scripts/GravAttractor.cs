using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravAttractor : MonoBehaviour {

	public float gravity = -10f;

	void Awake()
	{
	}

	public void Attract(Rigidbody rb) 
	{
		Vector3 gravityUp= (rb.position - transform.position).normalized;
		Vector3 targetDir = (rb.position - transform.position).normalized;
		Quaternion targetRotation = Quaternion.FromToRotation(rb.transform.up,gravityUp)*rb.rotation;

		rb.AddForce (targetDir * gravity);
		rb.MoveRotation(Quaternion.Slerp(rb.rotation,targetRotation,50f*Time.deltaTime));
	}
		
}
