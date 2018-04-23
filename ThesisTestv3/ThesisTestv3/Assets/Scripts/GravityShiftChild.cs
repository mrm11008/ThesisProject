using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShiftChild : MonoBehaviour {

	public Transform Parent;

	// Use this for initialization
	void Start () {
		//this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Parent != null) {
			//Invoke ("SetupGravCube", 0.5f);
			this.transform.position = Parent.transform.position;
			this.transform.parent = this.transform;
			this.gameObject.GetComponentInChildren<GameObject> ().SetActive (true);
		} else {
			this.transform.parent = null;
		}
		if (this.transform.parent != null) {
			//this.transform.rotation = this.transform.parent.rotation;
		}
	}

	public void SetupGravCube() {
		this.transform.position = Parent.transform.position;
		this.transform.parent = this.transform;
	}
}
