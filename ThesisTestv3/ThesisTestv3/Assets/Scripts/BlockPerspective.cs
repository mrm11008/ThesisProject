using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPerspective : MonoBehaviour {

	public Vector3 originalPosition;
	public Vector3 perspectivePosition;

	public Vector3 cameraDirection;
	public Vector3 platformDirection;

	public Rotate camera;

	public bool zerodPosition = false;
	public bool dontMove = true;

	public GravityNew blockGravity;
	public BlockPerspective block;

	public Transform Parent;
	public Vector3 difference;

	public GameObject fakeChild;
	public Perspective currentPlatform;

	// Use this for initialization
	void Start () {
		blockGravity = this.GetComponent<GravityNew> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Parent != null) {
			fakeChild.transform.position = Parent.transform.position;
			this.transform.parent = fakeChild.transform;
		}

		transform.rotation = Quaternion.identity;

		originalPosition = blockGravity.originalPosition;

		cameraDirection = camera.transform.forward;

		RaycastHit hit;

		if (((Vector3.Dot (cameraDirection, Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.up) < 1.1f)) && camera.turning == false) {

			if ((Vector3.Dot (cameraDirection, transform.up) > 0.9f) && (Vector3.Dot (cameraDirection, transform.up) < 1.1f)) {
				if (Physics.Raycast (transform.position, transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						dontMove = true;
					} else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
					} else {
						if (camera.turning == false && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
							Vector3 temp = transform.localPosition;
							temp.y = 0f;
							transform.localPosition = temp;
						}

					}
				}
			}

		} else if (((Vector3.Dot (cameraDirection, -Vector3.up) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.up) < 1.1f)) && camera.turning == false) {



			if ((Vector3.Dot (cameraDirection, -transform.up) > 0.9f) && (Vector3.Dot (cameraDirection, -transform.up) < 1.1f)) {
				if (Physics.Raycast (transform.position, -transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						dontMove = true;
					} else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
					} else {
						if (camera.turning == false && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
							Vector3 temp = transform.localPosition;
							temp.y = 0f;
							transform.localPosition = temp;
						}

					}
				}
			}

		} else {
			if (this.transform.parent == null  && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
				Vector3 temp = transform.localPosition;
				temp.y = originalPosition.y;
				transform.localPosition = temp;
			}

		}


		if (((Vector3.Dot (cameraDirection, Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.right) < 1.1f)) && camera.turning == false) {
			if (camera.turning == false && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
				if (currentPlatform != null && currentPlatform.xMove == false) {
					Vector3 temp = transform.localPosition;
					temp.x = 0f;
					transform.localPosition = temp;
				}


			}


		} 
		else if (((Vector3.Dot (cameraDirection, -Vector3.right) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.right) < 1.1f)) && camera.turning == false) {
			if (camera.turning == false && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
				if (currentPlatform != null && currentPlatform.xMove == false) {
					Vector3 temp = transform.localPosition;
					temp.x = 0f;
					transform.localPosition = temp;
				}
			}





		} else {
			if (this.transform.parent != null  && blockGravity.contact == true && blockGravity.gravityDisabled == true && camera.turning == false) {
				if (currentPlatform != null && currentPlatform.xMove == false) {
					Vector3 temp = transform.localPosition;
					temp.x = originalPosition.x;
					transform.localPosition = temp;
				}

			}

		}




		if (((Vector3.Dot (cameraDirection, Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, Vector3.forward) < 1.1f)) && camera.turning == false) {

			if (camera.turning == false && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
				if (currentPlatform != null && currentPlatform.zMove == false) {
					Vector3 temp = transform.localPosition;
					temp.z = 0f;
					transform.localPosition = temp;
				}

			}



		} 
		else if (((Vector3.Dot (cameraDirection, -Vector3.forward) > 0.9f) && (Vector3.Dot (cameraDirection, -Vector3.forward) < 1.1f)) && camera.turning == false) {

			if (camera.turning == false && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
				if (currentPlatform != null && currentPlatform.zMove == false) {
					Vector3 temp = transform.localPosition;
					temp.z = 0f;
					transform.localPosition = temp;
				}

			}



		} else {
			if (this.transform.parent != null && blockGravity.contact == true && blockGravity.gravityDisabled == true) {
				if (currentPlatform != null && block.currentPlatform.zMove == false) {
					zerodPosition = false;
					Vector3 temp = transform.localPosition;
					temp.z = originalPosition.z;
					transform.localPosition = temp;
				}
			}

		}
	}




	void OnTriggerEnter(Collider other){
		if (other.tag == "PressurePlate") {
			
			this.transform.parent = other.transform;
		}

		if (other.tag == "MovingPlatform" || other.tag == "PerspectiveBlock") {
			if (camera.turning == false) {
				currentPlatform = other.transform.gameObject.GetComponent<Perspective>();
				Parent = other.gameObject.transform;
			}
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "PressurePlate") {
			
			this.transform.parent = null;
		}

		if ((other.tag == "MovingPlatform" || other.tag == "PerspectiveBlock") && blockGravity.contact == false) {
			if (camera.turning == false) {
				currentPlatform = null;
				Parent = null;
			}

		}
	}

}
