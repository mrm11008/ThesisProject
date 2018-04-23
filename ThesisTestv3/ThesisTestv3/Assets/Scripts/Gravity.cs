using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	public Transform cameraPivot;
	public GameObject camera;

	public bool cameraDisabled;
	public Vector3 gravityValueY = new Vector3(0f, 0.1f, 0f);
	public Vector3 gravityValueX = new Vector3(0.1f, 0f, 0f);
	public bool contact = false;
	public int contactCount = 0;

	private Rigidbody rb;

	public float gravityValue = 0.1f;

	public bool gravityDisabled = true;
	public bool enteringTrigger = false;

	public int triggerCount = 0;

	public GameObject triggerCheck;
	// Use this for initialization
	void Start () {
		cameraDisabled = camera.GetComponent<CameraOrbit> ().CameraDisabled;
		rb = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (camera.transform.position, camera.transform.forward * 10, Color.green);
		if (Input.GetKeyDown (KeyCode.Space)) {
			triggerCheck = null;
            enteringTrigger = false;
			gravityDisabled = !gravityDisabled;
			//this.transform.position = Vector3.zero;
		}

		if (contact == false && gravityDisabled == true) {
			//fall off into oblivion
			//rb.freezeRotation = false;
			//rb.AddForce (Random.Range(1,2),Random.Range(1,2), Random.Range(1,2));
		}

		if (enteringTrigger == false) {
			gravityDisabled = false;
			contact = false;
		} else {
			gravityDisabled = true;
			contact = true;
		}

	}

	void OnCollisionEnter (Collision collision) {
        print("COLLIDE");
        print(collision.gameObject.name);
        //contact = true;
        if (enteringTrigger == true)
        {
            //gravityDisabled = true;
        }
        
        //if (contactCount == 1 && triggerCount != 1) {
        //if (contactCount == 1) {
        if (triggerCheck.transform.IsChildOf(collision.transform))
        {
            //gravityDisabled = true;
            print("true because of contact");
        }
        else
        {
            
        }



		//}
		contactCount++;

	}
		

	void OnCollisionExit (Collision collision) {
        contact = false;
        contactCount--;
		if (contactCount <= 0) {
			//contact = false;
			contactCount = 0;
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "EdgeTrigger") {
			triggerCheck = collider.gameObject;
			triggerCount++;
			//contact = false;
			//gravityDisabled = false;
			enteringTrigger = true;
		}


	}

	void OnTriggerStay(Collider collider) {
		if (collider.gameObject.tag == "EdgeTrigger") {

		}
	}
	void OnTriggerExit(Collider collider) {
        print("exiting trigger!!");
		if (collider.gameObject.tag == "EdgeTrigger") {
            contact = true;
            
            if (triggerCount > 1) {
				gravityDisabled = false;

				triggerCount--;
			} else {
				
				gravityDisabled = true;
				triggerCount--;
			}
				

			

		} else contact = false;
    }

	void FixedUpdate() {


		if (gravityDisabled == false) {
			//get camera rotation and apply gravity accordingly
			print(cameraPivot.rotation.eulerAngles);
			this.transform.position = transform.position + (-camera.transform.up) * (gravityValue) * Time.deltaTime;
            //this.transform.position = transform.position + (camera.transform.forward) * (gravityValue);
        }

		if (gravityDisabled == false) {
			//get camera rotation and apply gravity accordingly
			//print(cameraPivot.rotation.eulerAngles);
			//this.transform.position = camera.transform.forward * (- 0.1f);
		}


		if ((cameraPivot.eulerAngles == new Vector3(0, 180, 90)) || (cameraPivot.eulerAngles == new Vector3(0, 0, 270))) {
			if (gravityDisabled == false) {
				//this.transform.position = this.transform.position - gravityValueX;
			}

		}

		if (contact == false) {


		} else {
			//transform.Translate (2f*Input.GetAxis("Horizontal")*Time.deltaTime,0f, 2f*Input.GetAxis("Vertical")*Time.deltaTime);
			transform.position += 2f * Input.GetAxis ("Horizontal") * Time.deltaTime * camera.transform.right;
            //rb.AddForce(2f * Input.GetAxis("Horizontal") * camera.transform.right);

		}




		/*
		cameraDisabled = camera.GetComponent<CameraOrbit> ().CameraDisabled;
		if (cameraPivot.rotation.x < 90f && cameraPivot.rotation.x > 0f && cameraDisabled) {
			this.transform.position = this.transform.position - gravityValueY;
		} 
			
		if (cameraPivot.rotation.x > 90f) {
			this.transform.position = this.transform.position - gravityValueX;
		}
		*/
	}
}
