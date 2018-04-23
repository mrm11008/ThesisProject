using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateButton : MonoBehaviour {

	public Gate gate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OpenTheGate() {
		gate.Open ();
	}

	public void CloseTheGate() {
		gate.Close ();
	}
}
