using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Button") {
			other.gameObject.GetComponent<GateButton> ().OpenTheGate ();
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Button") {
			other.gameObject.GetComponent<GateButton> ().CloseTheGate ();
		}
	}
}
