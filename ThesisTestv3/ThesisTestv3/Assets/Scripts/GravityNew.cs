using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityNew : MonoBehaviour {

	public Transform cameraPivot;
	public GameObject camera;

	public bool cameraDisabled;
	public Vector3 gravityValueY = new Vector3(0f, 0.1f, 0f);
	public Vector3 gravityValueX = new Vector3(0.1f, 0f, 0f);
	public bool contact = true;
	public int contactCount = 0;

	private Rigidbody rb;

	public float gravityValue = 0.1f;

	public bool gravityDisabled = true;
	public bool enteringTrigger = false;

	public int triggerCount = 0;

	public GameObject triggerCheck;

	public Vector3 fallDirection;

	public bool grounded = false;
	public int groundCount = 0;

    public bool blockContact = false;


	public Vector3 originalPosition;
	public Vector3 testOriginalPosition;
	public Vector3 test2OriginalPosition;
	public Rotate cameraRotate;

	public bool gravityShift = false;

	public bool changeOP = false;



	public Perspective currentPlatform;

	// Use this for initialization
	void Start () {
		cameraDisabled = camera.GetComponent<CameraOrbit> ().CameraDisabled;
		rb = this.GetComponent<Rigidbody> ();


	}

	// Update is called once per frame
	void Update () {

		//Physics.gravity = (-camera.transform.up).normalized * 100f;

		Debug.DrawRay (camera.transform.position, -camera.transform.up * 10, Color.green);
		Debug.DrawRay (transform.position, transform.forward * 3, Color.green);

		Debug.DrawRay (transform.position, transform.up * 3, Color.blue);

		Debug.DrawRay (transform.position, transform.right * 0.6f, Color.red);


		if(Input.GetKeyDown(KeyCode.W)){

			//rb.AddForce(camera.transform.up * 50f, ForceMode.Impulse);

		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			test2OriginalPosition = this.transform.localPosition;
			if (currentPlatform.GetComponent<MovingPlatform> () != null) {
				//changeOP = false;
			} else {
				changeOP = true;
			}
			if (cameraRotate.turning == false) {
				//originalPosition = this.transform.localPosition;
			}
			if (gravityShift == false) {

				fallDirection = -camera.transform.up;
				Physics.gravity = (-camera.transform.up).normalized * 200f;
			} else {


				fallDirection = camera.transform.up;
				Physics.gravity = (camera.transform.up).normalized * 200f;
			}
			rb.isKinematic = false;
			if (contact == true) {
				GM.instance.GravitySound ();
				GM.instance.IncrementGravityShifts ();
			}
			contact = false;
			triggerCheck = null;
			enteringTrigger = false;
			gravityDisabled = !gravityDisabled;

			if (contact == false && gravityDisabled == true) {
				//fall off into oblivion
				//rb.freezeRotation = false;
				//rb.AddForce (Random.Range(1,2),Random.Range(1,2), Random.Range(1,2));
			}

		}

		if (currentPlatform.GetComponent<MovingPlatform> () != null) {
			
		} else {
			
			changeOP = true;
		}

	}

	void OnCollisionEnter (Collision collision) {
		print("COLLIDE");
		print(collision.gameObject.name);
		if (grounded == false && collision.gameObject.tag == "Ground" && groundCount > 0) {

			//Physics.IgnoreCollision (collision.gameObject.GetComponent<Collider> (), GetComponent<Collider> (), false);
		} else if (grounded == true && collision.gameObject.tag == "Ground") {
			//Physics.IgnoreCollision (collision.gameObject.GetComponent<Collider> (), GetComponent<Collider> (), true);
		}

		if (collision.gameObject.tag == "Ground") {

			if (gravityDisabled == false && contact == false) {
				GM.instance.DeathReset ();
			}

			//originalPosition = this.transform.localPosition;
			if (groundCount >= 1) {
				//i am already trouching the ground

			} else {
				//contact = true;
			}
			grounded = true;
			groundCount++;
		}

        if (collision.gameObject.tag == "Block")
        {
			//originalPosition = this.transform.localPosition;
            //rb.velocity = new Vector3(0, 0, 0);
            //blockContact = true;
            //gravityDisabled = true;
            //contact = true;
        }
        if (collision.gameObject.tag == "Player")
        {
			//originalPosition = this.transform.localPosition;
            //rb.velocity = new Vector3(0, 0, 0);
            //blockContact = true;
            //gravityDisabled = true;
            //contact = true;
        }



    }

	void OnCollisionStay(Collision collision) {
		//contact = true;
		if (collision.gameObject.tag == "Ground") {
			grounded = true;
		}
	}


	void OnCollisionExit (Collision collision) {
		//contact = false;
		if (collision.gameObject.tag == "Ground") {
            print("I LEFT THE GROUND");
			//grounded = false;

			if (groundCount > 1) {
				grounded = true;
				groundCount--;
			} else {
				grounded = false;
				groundCount--;
			}
		}


        if (collision.gameObject.tag == "Block")
        {
            //blockContact = false;
        }
    }

	void OnTriggerEnter(Collider collider) {

        if (collider.tag == "StopPad")
        {
			if (contact == true && gravityDisabled == true) {

			} else {
				
				this.transform.position = collider.transform.position;
				originalPosition = this.transform.localPosition;
			}
            contact = true;
            gravityDisabled = true;
			grounded = true;
			groundCount = 1;




	
            //this.transform.position = new Vector3 (0, 1, 0);
            //transform.position = Vector3.Lerp(transform.position, new Vector3(0, 1, 0), 2f);
            rb.isKinematic = true;

        }
        if (collider.tag == "TeleportPad")
        {
            //contact = true;
            //gravityDisabled = true;
            this.transform.position = new Vector3(0, -1, 3);
        }

	}

	void OnTriggerStay(Collider collider) {

	}
	void OnTriggerExit(Collider collider) {

	}

	void FixedUpdate() {

		if (gravityDisabled == true) {
			//rb.isKinematic = true;
			rb.useGravity = false;

            //rb.isKinematic = true;
		} else {
            //rb.isKinematic = false;
            //rb.isKinematic = false;
			rb.useGravity = true;
            
		}

		//raycast wall checks
		RaycastHit hit;

		if (Physics.Raycast (transform.position, -transform.right, out hit, 0.6f)) {
			print ("found object:" + hit.collider.gameObject.tag);

		}


		//Gravity Checks


		if (contact == true) {
            //rb.isKinematic = true;
            gravityDisabled = true;
		} else {
            //rb.isKinematic = false;
            gravityDisabled = false;
            
        }

		
		if (gravityDisabled == false && contact == false) {
			//get camera rotation and apply gravity accordingly
			//print(cameraPivot.rotation.eulerAngles);

			//DOT PRODUCT

			if ((Vector3.Dot (fallDirection, -transform.right) > 0.9f) && (Vector3.Dot (fallDirection, -transform.right) < 1.1f)) {
				print ("DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, -transform.right, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);

						rb.isKinematic = true;
                        contact = true;
                        gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
                        if (blockContact == false)
                        {
                            //rb.velocity = new Vector3(0, 0, 0);
                            contact = true;
                            gravityDisabled = true;
                        }
                    }
					else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
						contact = true;
						gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
					} else {
						rb.isKinematic = false;
						contact = false;
						gravityDisabled = false;
					}


				}
			} else if ((Vector3.Dot (fallDirection, transform.right) > 0.9f) && (Vector3.Dot (fallDirection, transform.right) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, transform.right, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
                        contact = true;
                        gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
                        if (blockContact == false)
                        {
                            //rb.velocity = new Vector3(0, 0, 0);
                            contact = true;
                            gravityDisabled = true;

                        }
					}
					else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
						contact = true;
						gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
					} else {
						rb.isKinematic = false;
						contact = false;
						gravityDisabled = false;
					}
				}
				
			} else if ((Vector3.Dot (fallDirection, -transform.up) > 0.9f) && (Vector3.Dot (fallDirection, -transform.up) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, -transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
                        contact = true;
                        gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
                        if (blockContact == false)
                        {
                            //rb.velocity = new Vector3(0, 0, 0);
                            contact = true;
                            gravityDisabled = true;

                        }
                    }
					else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
						contact = true;
						gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
					} else {
						rb.isKinematic = false;
						contact = false;
						gravityDisabled = false;
					}
				}


			} else if ((Vector3.Dot (fallDirection, transform.up) > 0.9f) && (Vector3.Dot (fallDirection, transform.up) < 1.1f)) {

				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
                        contact = true;
                        gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
                        if (blockContact == false)
                        {
                            //rb.velocity = new Vector3(0, 0, 0);
                            contact = true;
                            gravityDisabled = true;

                        }
                    }
					else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
						contact = true;
						gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
					} else {
						rb.isKinematic = false;
						contact = false;
						gravityDisabled = false;
					}
				}

			} else if ((Vector3.Dot (fallDirection, -transform.forward) > 0.9f) && (Vector3.Dot (fallDirection, -transform.forward) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, -transform.forward, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
                        contact = true;
                        gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
                        if (blockContact == false)
                        {
                            //rb.velocity = new Vector3(0,0,0);
                            contact = true;
                            gravityDisabled = true;

                        }
                    }
					else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
						contact = true;
						gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
					} else {
						rb.isKinematic = false;
						contact = false;
						gravityDisabled = false;
					}
				}

			} else if ((Vector3.Dot (fallDirection, transform.forward) > 0.9f) && (Vector3.Dot (fallDirection, transform.forward) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, transform.forward, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
                        contact = true;
                        gravityDisabled = true;
	
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
						if (blockContact == false)
                        {
                            //rb.velocity = new Vector3(0, 0, 0);
                            contact = true;
                            gravityDisabled = true;

                        }
                    }
					else if (hit.collider.gameObject.tag == "Ground" || (hit.collider.gameObject.tag == "Block" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true) || (hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.GetComponent<GravityNew> ().gravityDisabled == true)) {
						print ("found object:" + hit.collider.gameObject.tag);
						rb.isKinematic = true;
						contact = true;
						gravityDisabled = true;
						if (cameraRotate.turning == false && changeOP == true) {
							testOriginalPosition = this.transform.localPosition;
						}
					} else {
						rb.isKinematic = false;
						contact = false;
						gravityDisabled = false;
					}
				}
			}



			if (contact == true && gravityDisabled == true && cameraRotate.turning == false && changeOP == true ) {
				if (testOriginalPosition != test2OriginalPosition) {
					originalPosition = this.transform.localPosition;
				} else {
					originalPosition = testOriginalPosition;
				}

			}

		}



		///SEPERATE WALL CHECKS



		float moveHorizontal = Input.GetAxis ("Horizontal");


		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0f);
		Vector3 movement = camera.transform.right * moveHorizontal;
		rb.velocity = movement * 3f;
		//rb.AddForce (movement * 3f);






	}


	public void ChangePosition() {
		originalPosition = this.transform.localPosition;
	}

}
