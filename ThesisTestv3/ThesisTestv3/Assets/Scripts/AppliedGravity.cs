using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppliedGravity : MonoBehaviour {

    //public float gravityValue = 0.05f;
    public GameObject camera;

    public GravityNew player;

    public bool gravityDisabled = true;
    public Vector3 fallVector;

	public bool contact = true;
	public Vector3 fallDirection;
	public bool falling = false;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
	}
    private void Update()
    {
		//Physics.gravity = (-camera.transform.up);

            if (Input.GetKeyDown(KeyCode.Space))
            {
				falling = true;
				fallDirection = camera.transform.up;
				contact = false;
                gravityDisabled = !gravityDisabled;
                //fallVector = camera.transform.forward;
				fallVector = -camera.transform.up;
            }

        
    }
    // Update is called once per frame
    void FixedUpdate () {

		if (gravityDisabled == true) {
			//rb.isKinematic = true;
			rb.useGravity = false;
		} else {
			//rb.isKinematic = false;
			rb.useGravity = true;
		}

		if (contact == true) {
			gravityDisabled = true;
		} else {
			gravityDisabled = false;
		}
			


		//if (gravityDisabled == false && contact == false)
       // {
		//	this.transform.position = transform.position + (fallVector) * (gravityValue) * Time.deltaTime;;
        //}
		RaycastHit hit;
		if (gravityDisabled == false && contact == false) {
			//get camera rotation and apply gravity accordingly
			//print(cameraPivot.rotation.eulerAngles);

			//DOT PRODUCT
			if ((Vector3.Dot (-camera.transform.up, -transform.right) > 0.9f) && (Vector3.Dot (-fallDirection, -transform.right) < 1.1f)) {
				print ("DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, -transform.right, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						contact = true;
						gravityDisabled = true;


					} else {
						//this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
					}


					if (hit.collider.gameObject.tag == "Player") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

					if (hit.collider.gameObject.tag == "Block") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}


				} else {
					//this.transform.position = transform.position + (-fallDirection) * (gravityValue) * Time.deltaTime;
				}
			} else if ((Vector3.Dot (-camera.transform.up, transform.right) > 0.9f) && (Vector3.Dot (-camera.transform.up, transform.right) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, transform.right, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						contact = true;
						gravityDisabled = true;
					} else {
						//this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
					}

					if (hit.collider.gameObject.tag == "Player") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

					if (hit.collider.gameObject.tag == "Block") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

				} else {
					//this.transform.position = transform.position + (-fallDirection) * (gravityValue) * Time.deltaTime;
				}

			} else if ((Vector3.Dot (-camera.transform.up, -transform.up) > 0.9f) && (Vector3.Dot (-camera.transform.up, -transform.up) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, -transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						contact = true;
						gravityDisabled = true;
					} else {
						//this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
					}

					if (hit.collider.gameObject.tag == "Player") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

					if (hit.collider.gameObject.tag == "Block") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

				} else {
					//this.transform.position = transform.position + (-fallDirection) * (gravityValue) * Time.deltaTime;
				}


			} else if ((Vector3.Dot (-camera.transform.up, transform.up) > 0.9f) && (Vector3.Dot (-fallDirection, transform.up) < 1.1f)) {

				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, transform.up, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						contact = true;
						gravityDisabled = true;
					} else {
						//this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
					}

					if (hit.collider.gameObject.tag == "Player") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

					if (hit.collider.gameObject.tag == "Block") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

				} else {
					//this.transform.position = transform.position + (-fallDirection) * (gravityValue) * Time.deltaTime;
				}

			} else if ((Vector3.Dot (-camera.transform.up, -transform.forward) > 0.9f) && (Vector3.Dot (-fallDirection, -transform.forward) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, -transform.forward, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						contact = true;
						gravityDisabled = true;
					} else {
						//this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
					}

					if (hit.collider.gameObject.tag == "Player") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

					if (hit.collider.gameObject.tag == "Block") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

				} else {
					//this.transform.position = transform.position + (-fallDirection) * (gravityValue) * Time.deltaTime;
				}

			} else if ((Vector3.Dot (-camera.transform.up, transform.forward) > 0.9f) && (Vector3.Dot (-camera.transform.up, transform.forward) < 1.1f)) {
				print (" NEW DOT PRODUCT IS THE SAME");
				if (Physics.Raycast (transform.position, transform.forward, out hit, 0.6f)) {
					if (hit.collider.gameObject.tag == "Wall") {
						print ("found object:" + hit.collider.gameObject.tag);
						contact = true;
						gravityDisabled = true;
					} else {
						//this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
					}

					if (hit.collider.gameObject.tag == "Player") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

					if (hit.collider.gameObject.tag == "Block") {
						if (hit.collider.gameObject.GetComponent<GravityNew> ().contact == true) {
							contact = true;
							gravityDisabled = true;
						}
					}

				} else {
					//this.transform.position = transform.position + (-fallDirection) * (gravityValue) * Time.deltaTime;
				}
			}

			//this.transform.position = transform.position + (camera.transform.forward) * (gravityValue);
		}


    }

 	void OnCollisionEnter(Collision collision)
    {
		print ("cube collision");
		contact = true;
        //gravityDisabled = true;
    }

	void OnCollisionExit(Collision collision)
	{
		contact = false;
		//gravityDisabled = true;
	}
}
