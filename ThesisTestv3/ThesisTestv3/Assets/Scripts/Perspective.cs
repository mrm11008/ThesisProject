using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour {

	public Vector3 originalPosition;
	private Vector3 cleanOriginalPosition;
	private Vector3 plusOriginalPosition;
	private Vector3 minusOriginalPosition;

	public Vector3 cameraDirection;
	public Transform platform;

	public Rotate camera;

	public bool xMove = false;
	public bool yMove = false;
	public bool zMove = false;

	public MovingPlatform movingPlatform;
	public bool moving = false;

	public GravityNew playerGravity;
	public bool shiftChanges = false;


	//Code to declare the number of perspective positions

	// Use this for initialization
	void Start () {
		originalPosition = this.transform.position;
		cleanOriginalPosition = this.transform.position;

		movingPlatform = this.GetComponent<MovingPlatform> ();
		if(movingPlatform != null) {
			plusOriginalPosition = originalPosition + movingPlatform.negativeMoveVector;

		}
		playerGravity = GameObject.FindGameObjectWithTag("Player").GetComponent<GravityNew>();
	}

	// Update is called once per frame
	void FixedUpdate () {


		if (movingPlatform != null) {
			moving = movingPlatform.moving;
			if (moving == false) {

				if (movingPlatform.negativeMove == true) {
					originalPosition = plusOriginalPosition;
				} else {
					originalPosition = cleanOriginalPosition;

				}


			if (playerGravity.gravityShift == true) {
				//plusOriginalPosition = cleanOriginalPosition - movingPlatform.negativeMoveVector;
			}
			if (movingPlatform.negativeMove == true && playerGravity.gravityShift == false) {
				originalPosition = plusOriginalPosition;
			} else if (movingPlatform.positiveMove == true && playerGravity.gravityShift == true) {
				//originalPosition = plusOriginalPosition;
			} else if (movingPlatform.negativeMove == true && playerGravity.gravityShift == true) {
				//originalPosition = cleanOriginalPosition;
			} else {
				//originalPosition = cleanOriginalPosition;

			}
			}

		}
		if (Input.GetKeyDown (KeyCode.Space)) {

		}

		Debug.DrawRay (transform.position, transform.forward * 3, Color.green);

		Debug.DrawRay (transform.position, transform.up * 3, Color.blue);

		Debug.DrawRay (transform.position, transform.right * 0.6f, Color.red);

		cameraDirection = camera.transform.forward;
		/*
		if (((Vector3.Dot (cameraDirection, platformDirection) > 0.9f) && (Vector3.Dot (cameraDirection, platformDirection) < 1.1f)) && camera.turning == false) {
			this.transform.position = perspectivePosition;
		} else if (((Vector3.Dot (cameraDirection, -platformDirection) > 0.9f) && (Vector3.Dot (cameraDirection, -platformDirection) < 1.1f)) && camera.turning == false) {
			this.transform.position = perspectivePosition;
		} else {
			this.transform.position = originalPosition;
		}
		*/

		if (moving == false) {
		//used to have a is camera.turning == false part of if 
		if (((Vector3.Dot (cameraDirection, Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.up) < 1.1f) && camera.turning == false) ) {
			Vector3 temp = transform.position;
			temp.y = 0f;
			transform.position = temp;
		} else if (((Vector3.Dot (cameraDirection, -Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.up) < 1.1f)) && camera.turning == false) {
			Vector3 temp = transform.position;
			temp.y = 0f;
			transform.position = temp;
		} else {
			Vector3 temp = transform.position;
			temp.y = originalPosition.y;
			transform.position = temp;
		}

		if (((Vector3.Dot (cameraDirection, Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.forward) < 1.1f)&& camera.turning == false) ) {
			Vector3 temp = transform.position;
			temp.z = 0f;
			transform.position = temp;
		} else if (((Vector3.Dot (cameraDirection, -Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.forward) < 1.1f)) && camera.turning == false) {
			Vector3 temp = transform.position;
			temp.z = 0f;
			transform.position = temp;
		} else {
			Vector3 temp = transform.position;
			temp.z = originalPosition.z;
			transform.position = temp;
		}

		if (((Vector3.Dot (cameraDirection, Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.right) < 1.1f))&& camera.turning == false) {
			Vector3 temp = transform.position;
			temp.x = 0f;
			transform.position = temp;
		} else if (((Vector3.Dot (cameraDirection, -Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.right) < 1.1f))&& camera.turning == false) {
			Vector3 temp = transform.position;
			temp.x = 0f;
			transform.position = temp;
		} else {
			Vector3 temp = transform.position;
			temp.x = originalPosition.x;
			transform.position = temp;
		}

		}


		/*
		if (((Vector3.Dot (cameraDirection, platformDirectionTwo) > 0.9f) && (Vector3.Dot (cameraDirection, platformDirectionTwo) < 1.1f)) && camera.turning == false) {
			this.transform.position = perspectivePosition;
		} else if (((Vector3.Dot (cameraDirection, -platformDirectionTwo) > 0.9f) && (Vector3.Dot (cameraDirection, -platformDirectionTwo) < 1.1f)) && camera.turning == false) {
			this.transform.position = perspectivePositionTwo;
		} else {
			this.transform.position = originalPosition;
		}
		*/

	}
}
