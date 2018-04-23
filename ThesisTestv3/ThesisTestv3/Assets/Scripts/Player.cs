using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public bool onRotatingPlatform {get; set;}

	public Transform Parent;
	public Vector3 difference;

	public GameObject fakeChild;
	public GravityNew gravity;

	public Perspective currentPlatform;

	public Rotate camera;

	// Use this for initialization
	void Start () {
		gravity = this.GetComponent<GravityNew> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Parent != null) {
			//difference = Parent.transform.position + transform.position;
			//transform.position = Parent.transform.position + difference;
			fakeChild.transform.position = Parent.transform.position;
			this.transform.parent = fakeChild.transform;
		} else {
			this.transform.parent = null;
		}
		if (this.transform.parent != null) {
			//this.transform.rotation = this.transform.parent.rotation;
		}
	}





	void OnTriggerEnter(Collider other){

		if (other.tag == "Coin") {
			GM.instance.CoinSound ();
			Destroy (other.gameObject);
			GM.instance.IncrementCoins ();
		}

		if (other.tag == "PressurePlate") {
			onRotatingPlatform = true;
			this.transform.parent = other.transform;
			//Try and implement a "STICK" functionality
			//other.gameObject.GetComponent<RotatePlatform> ().Rotate();
		}

		if (other.tag == "GravityShift") {
			if (camera.turning == false) {
				this.GetComponent<GravityNew> ().gravityShift = !this.GetComponent<GravityNew> ().gravityShift;


			} else {
				//this.GetComponent<GravityNew> ().gravityShift = false;
			}
		}
		if (other.tag == "MovingPlatform" || other.tag == "PerspectiveBlock") {
			//this.transform.parent = other.gameObject.transform;
			//fakeChild.transform.position = other.gameObject.transform.position;

			if (camera.turning == false) {
				currentPlatform = other.transform.gameObject.GetComponent<Perspective>();
				this.GetComponent<GravityNew> ().currentPlatform = currentPlatform;
				Parent = other.gameObject.transform;
			}


		}

		if (other.tag == "death") {
			GM.instance.DeathReset ();
		}
			
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "PressurePlate") {
			onRotatingPlatform = false;
			this.transform.parent = null;

		}

		if ((other.tag == "MovingPlatform" || other.tag == "PerspectiveBlock") && gravity.contact == false) {
			//this.transform.parent = null;

			if (camera.turning == false) {
				currentPlatform = null;
				Parent = null;
			}

		}
	}






}
