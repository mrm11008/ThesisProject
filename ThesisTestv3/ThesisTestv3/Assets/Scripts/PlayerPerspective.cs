using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerspective : MonoBehaviour {
	
	public Vector3 originalPosition;
	public Vector3 perspectivePosition;

	public Vector3 cameraDirection;
	public Vector3 platformDirection;

	public Rotate camera;

	public bool zerodPosition = false;
	public bool dontMove = true;

	public GravityNew playerGravity;
	public Player player;
	// Use this for initialization
	void Start () {
		playerGravity = this.GetComponent<GravityNew> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = Quaternion.identity;

		if (camera.turning == false) {
			//originalPosition = this.transform.position;
		}
		if (camera.turning == false && playerGravity.contact == true && playerGravity.gravityDisabled == true) {
			//originalPosition = this.transform.position;
			//originalPosition = this.transform.localPosition;

		}
		originalPosition = playerGravity.originalPosition;

		cameraDirection = camera.transform.forward;

		RaycastHit hit;

		if (((Vector3.Dot (cameraDirection, Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.up) < 1.1f))) {

			zerodPosition = true;
			dontMove = false;
			if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				if (player.currentPlatform != null && player.currentPlatform.yMove == false && camera.turning == false) {
					Vector3 temp = transform.localPosition;
					temp.y = 0f;
					transform.localPosition = temp;
				}
			}
		} 
		else if (((Vector3.Dot (cameraDirection, -Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.up) < 1.1f)) ) {

			dontMove = false;
			zerodPosition = true;
			if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				//originalPosition = this.transform.position;
				//originalPosition = this.transform.position;
				if (player.currentPlatform != null && player.currentPlatform.yMove == false && camera.turning == false) {
					Vector3 temp = transform.localPosition;
					temp.y = 0f;
					transform.localPosition = temp;
				}
			}





		} else {

			//dontMove = false;
			if (this.transform.parent != null  && playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				print ("change back");
				zerodPosition = false;
				if (player.currentPlatform != null && player.currentPlatform.yMove == false && camera.turning == false) {
					Vector3 temp = transform.localPosition;
					temp.y = originalPosition.y;
					transform.localPosition = temp;
				}

			}

		}

		/*
		if (((Vector3.Dot (cameraDirection, Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.up) < 1.1f)) ) {

				if (Physics.Raycast (transform.position, transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						dontMove = true;
					} else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						dontMove = true;
					} else {
						dontMove = false;
						zerodPosition = true;
						if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
							Vector3 temp = transform.localPosition;
							temp.y = originalPosition.y;
							transform.localPosition = temp;
						}

					}
				}

		} else if (((Vector3.Dot (cameraDirection, -Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.up) < 1.1f))) {
				if (Physics.Raycast (transform.position, -transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						dontMove = true;
					} else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						dontMove = true;
					} else {
						dontMove = false;
						zerodPosition = true;
						if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
							Vector3 temp = transform.localPosition;
							temp.y = originalPosition.y;
							transform.localPosition = temp;
						}

					}
				}

		} else {
			if (this.transform.parent != null  && playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				zerodPosition = false;
				Vector3 temp = transform.localPosition;
				temp.y = originalPosition.y;
				transform.localPosition = temp;
			}

		}
		*/

		if (((Vector3.Dot (cameraDirection, Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.right) < 1.1f))) {

			zerodPosition = true;
			dontMove = false;
			if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				if (player.currentPlatform != null && player.currentPlatform.xMove == false && camera.turning == false) {
					Vector3 temp = transform.localPosition;
					temp.x = 0f;
					transform.localPosition = temp;
				}
			}
		} 
		else if (((Vector3.Dot (cameraDirection, -Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.right) < 1.1f)) ) {

			dontMove = false;
			zerodPosition = true;
			if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				//originalPosition = this.transform.position;
				//originalPosition = this.transform.position;
				if (player.currentPlatform != null && player.currentPlatform.xMove == false && camera.turning == false) {
					Vector3 temp = transform.localPosition;
					temp.x = 0f;
					transform.localPosition = temp;
				}
			}





		} else {
			
			//dontMove = false;
			if (this.transform.parent != null  && playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				print ("change back");
				zerodPosition = false;
				if (player.currentPlatform != null && player.currentPlatform.xMove == false && camera.turning == false) {
					Vector3 temp = transform.localPosition;
					temp.x = originalPosition.x;
					transform.localPosition = temp;
				}

			}

		}


	

		if (((Vector3.Dot (cameraDirection, Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.forward) < 1.1f)) ) {

			if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				if (player.currentPlatform != null && player.currentPlatform.zMove == false && camera.turning == false) {
					dontMove = false;
					zerodPosition = true;
					Vector3 temp = transform.localPosition;
					temp.z = 0f;
					transform.localPosition = temp;
				}

			}



		} 
		else if (((Vector3.Dot (cameraDirection, -Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.forward) < 1.1f)) ) {

			if (playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				if (player.currentPlatform != null && player.currentPlatform.zMove == false && camera.turning == false) {
					dontMove = false;
					zerodPosition = true;
					Vector3 temp = transform.localPosition;
					temp.z = 0f;
					transform.localPosition = temp;
				}

			}

		} else {

			//dontMove = false;
			if (this.transform.parent != null && playerGravity.contact == true && playerGravity.gravityDisabled == true) {
				print ("change back");


				if (player.currentPlatform != null && player.currentPlatform.zMove == false && camera.turning == false) {
					zerodPosition = false;
					Vector3 temp = transform.localPosition;
					temp.z = originalPosition.z;
					transform.localPosition = temp;
				}
			}

		}




		/*
		if (((Vector3.Dot (cameraDirection, Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.forward) < 1.1f)) && camera.turning == false) {
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

		if (((Vector3.Dot (cameraDirection, Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.right) < 1.1f)) && camera.turning == false) {
			Vector3 temp = transform.position;
			temp.x = 0f;
			transform.position = temp;
		} else if (((Vector3.Dot (cameraDirection, -Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.right) < 1.1f)) && camera.turning == false) {
			Vector3 temp = transform.position;
			temp.x = 0f;
			transform.position = temp;
		} else {
			Vector3 temp = transform.position;
			temp.x = originalPosition.x;
			transform.position = temp;
		}
		*/
	}
}
