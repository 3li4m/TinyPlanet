using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour {


	Camera MainCamera;
	public bool useController;
	public GunController gun;
	//Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		//rb = GetComponentInParent<Rigidbody> ();
		MainCamera = Camera.main;
	}

	// Update is called once per frame
	void Update () {

		if (!useController) 
		{
			Ray cameraRay = MainCamera.ScreenPointToRay (Input.mousePosition);
			Plane groundPlane = new Plane (Vector3.up, Vector3.zero);

			float rayLength;
			if (groundPlane.Raycast (cameraRay, out rayLength)) 
			{
				Vector3 pointToLook = cameraRay.GetPoint (rayLength);
				transform.LookAt (new Vector3 (pointToLook.x, transform.position.y, pointToLook.z));
			}
		} 
		else 
		{
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw ("RHorizontal") + Vector3.forward* -Input.GetAxisRaw ("RVertical");
			if (playerDirection.sqrMagnitude > 0.0f) 
			{
				transform.rotation = Quaternion.LookRotation (playerDirection, Vector3.up);
				gun.Shoot ();
			}
		}
	
	}
}
