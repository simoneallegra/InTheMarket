using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour {

	[SerializeField] Transform target;
	[SerializeField] float smothspeed = 0.1f;
	[SerializeField] Vector3 distance;
	private Vector3 targetPosition;
	private Camera mainCamera;
	private float scrollValue;

	void Update () {

		if(distance.y <3f){

			distance.y=3;
			distance.z = -1;
			targetPosition = target.position + distance;

		}else if(distance.y > 6f){

			distance.y=6;
			distance.z = -3;
			targetPosition = target.position + distance;

		}else targetPosition = target.position + distance;

		
		//movimento costante:
		Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smothspeed);
		transform.position=smoothPosition;
		//---
		transform.LookAt(target);

		if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)){

			scrollValue = Input.GetAxis("Mouse ScrollWheel");

			distance.y -= scrollValue*5f;
			distance.z += scrollValue*3.5f;

		}

	}

}
