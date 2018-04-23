using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {


	public Transform rotateTo;

	public GameObject player;
	public bool contact = true;

	public float waitTime = 1.1f;

	public bool turning = false;

	public float rotateTime = 0.25f;

	public bool onRotatingPlatform = false;

	public GameObject camera;

    //rotating platforms
    public RotatePlatform platform1;

	// Use this for initialization
	void Start () {
		contact = player.GetComponent<GravityNew> ().contact;
	}
	
	// Update is called once per frame
	void Update () {
		//contact = player.GetComponent<Gravity> ().contact;
		onRotatingPlatform = player.GetComponent<Player> ().onRotatingPlatform;
		Debug.DrawRay (camera.transform.position, camera.transform.forward * 3, Color.green);

		Debug.DrawRay (camera.transform.position, camera.transform.up * 3, Color.blue);

		Debug.DrawRay (transform.position, transform.right * 0.6f, Color.red);
	}

	void FixedUpdate() {

	}

	void LateUpdate() {
		var fromAngle = transform.rotation;
		var toAngle = Quaternion.Euler (transform.eulerAngles + new Vector3 (90f, 0f, 0f));



		if (Input.GetKeyDown(KeyCode.UpArrow) && contact == true && turning == false && onRotatingPlatform == false && player.GetComponent<GravityNew>().gravityDisabled == true && player.GetComponent<GravityNew>().contact == true ) {
			//print ("UP");
			//print ("y degree" + this.transform.eulerAngles.y);
			//print ("z degree" + this.transform.eulerAngles.z);
            StartCoroutine(Rotation(this.transform, new Vector3(90, 0, 0), rotateTime));
			GM.instance.IncrementRotations ();
            if ((this.transform.eulerAngles.y == 0 || this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.y == 180 || this.transform.eulerAngles.z == 180) || (this.transform.eulerAngles.y == 90 || this.transform.eulerAngles.z == 90) || (this.transform.eulerAngles.y == 270 || this.transform.eulerAngles.z == 270)) {



				//this.gameObject.transform.Rotate (90, 0, 0);


				


				//transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.eulerAngles.x + 90, 0, 0));
			} else if (this.transform.eulerAngles.z == 90) {

				//this.transform.Rotate (90, 0, 0);
				//this.gameObject.transform.Rotate (90, 0, 0);
				//StartCoroutine (Rotation(this.transform, new Vector3(90,0,0), rotateTime));

			} else if (this.transform.eulerAngles.z == 270) {
				
				//this.transform.Rotate (90, 0, 0);
				//this.gameObject.transform.Rotate (90, 0, 0);
				//StartCoroutine (Rotation(this.transform, new Vector3(90,0,0), rotateTime));




			}
		}

		if (Input.GetKeyDown(KeyCode.DownArrow) && contact == true && turning == false && onRotatingPlatform == false && player.GetComponent<GravityNew>().gravityDisabled == true && player.GetComponent<GravityNew>().contact == true) {
			//print ("DOWN");
			//print ("y degree" + this.transform.eulerAngles.y);
			//print ("z degree" + this.transform.eulerAngles.z);
            StartCoroutine(Rotation(this.transform, new Vector3(-90, 0, 0), rotateTime));
			GM.instance.IncrementRotations ();

            if ((this.transform.eulerAngles.y == 0 || this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.y == 180 || this.transform.eulerAngles.z == 180) || (this.transform.eulerAngles.y == 90 || this.transform.eulerAngles.z == 90) || (this.transform.eulerAngles.y == 270 || this.transform.eulerAngles.z == 270)) {
				//StartCoroutine (Rotation(this.transform, new Vector3(-90,0,0), rotateTime));
				//this.transform.Rotate (-90, 0, 0);
			} else if (this.transform.eulerAngles.z == 90) {
				//StartCoroutine (Rotation(this.transform, new Vector3(-90,0,0), rotateTime));
				//this.transform.Rotate (-90, 0, 0);
			} else if (this.transform.eulerAngles.z == 270) {
				
				//this.transform.Rotate (-90, 0, 0);

			}
		}


		if (Input.GetKeyDown(KeyCode.RightArrow) && contact == true && turning == false && onRotatingPlatform == false && player.GetComponent<GravityNew>().gravityDisabled == true && player.GetComponent<GravityNew>().contact == true) {

			//print ("Right");
			//print ("x degree" + this.transform.eulerAngles.x);
			//print ("z degree" + this.transform.eulerAngles.z);
            StartCoroutine(Rotation(this.transform, new Vector3(0, -90, 0), rotateTime));
			GM.instance.IncrementRotations ();

            
            if ((this.transform.eulerAngles.x == 0 && this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.x == -180 || this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.x == 0 || this.transform.eulerAngles.z == -180) || (this.transform.eulerAngles.x == 0 || this.transform.eulerAngles.z == 180)) {
                platform1.Rotate(new Vector3(0, -90, 0));
            }
            if ((this.transform.eulerAngles.x == 0 || this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.x == 180 || this.transform.eulerAngles.z == 180) || (this.transform.eulerAngles.x == 270 || this.transform.eulerAngles.z == 270) || (this.transform.eulerAngles.x == 90 || this.transform.eulerAngles.z == 90)) {
				//this.transform.Rotate (0, -90, 0);
				
			}
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow) && contact == true && turning == false && onRotatingPlatform == false && player.GetComponent<GravityNew>().gravityDisabled == true && player.GetComponent<GravityNew>().contact == true) {

			//print ("Right");
			//print ("x degree" + this.transform.eulerAngles.x);
			//print ("z degree" + this.transform.eulerAngles.z);
            StartCoroutine(Rotation(this.transform, new Vector3(0, 90, 0), rotateTime));
			GM.instance.IncrementRotations ();

            if ((this.transform.eulerAngles.x == 0 && this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.x == -180 || this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.x == 0 || this.transform.eulerAngles.z == -180) || (this.transform.eulerAngles.x == 0 || this.transform.eulerAngles.z == 180))
            {
                platform1.Rotate(new Vector3(0, 90, 0));
            }
            if ((this.transform.eulerAngles.x == 0 || this.transform.eulerAngles.z == 0) || (this.transform.eulerAngles.x == 180 || this.transform.eulerAngles.z == 180) || (this.transform.eulerAngles.x == 270 || this.transform.eulerAngles.z == 270 || (this.transform.eulerAngles.x == 90 || this.transform.eulerAngles.z == 90))) {
				//this.transform.Rotate (0, 90, 0);
				
			}
		}
	}






	public IEnumerator Rotation(Transform thisTransform, Vector3 degrees, float time) {
		GM.instance.TurnSound ();
		print ("Rotate called");
		turning = true;
		Quaternion startRotation = thisTransform.rotation;
		Quaternion endRotation = thisTransform.rotation * Quaternion.Euler (degrees);
		float rate = 1.0f / time;
		float t = 0.0f;
		while (t < 1.0f) {
			t += Time.deltaTime * rate;
			thisTransform.rotation = Quaternion.Slerp (startRotation, endRotation, t);
			yield return null;
		}
		turning = false;
	}
}
