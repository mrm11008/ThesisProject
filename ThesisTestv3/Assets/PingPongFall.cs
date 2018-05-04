using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.PingPong(Time.time/2, 0.1f));
    }
}
